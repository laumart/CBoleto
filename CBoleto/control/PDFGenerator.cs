using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CBoleto.control
{
    class PDFGenerator
    {
        private Document document;
        private PdfContentByte cb;
        private PdfTemplate tempImgBoleto;
        private PdfTemplate tempImgBoletoSup; //Incluido lau
        private PdfTemplate tempImgBanco;
        private PdfTemplate tempImgMarketing;
        private const float IMAGEM_BOLETO_WIDTH = 514.22f;
        private const float IMAGEM_BOLETO_HEIGHT = 385.109f;
        private const float IMAGEM_BANCO_WIDTH = 100.0f;
        private const float IMAGEM_BANCO_HEIGHT = 23.0f;
        private const float IMAGEM_MARKETING_WIDTH = 511.2f;
        private const float IMAGEM_MARKETING_HEIGHT = 3341.3f;
        Image imgTitulo = null;
        Image imgTituloSup = null; //Incluido lau
                                   //gera template com a imagem do marketing
        Image imgMarketing = null;
        Image imgBanco = null;


        public PDFGenerator(String template, BoletoBean boleto, Banco banco)
        {

            //string tempPath = AppDomain.CurrentDomain.BaseDirectory + boleto.Banco + "_" + 
            //                                        boleto.NossoNumero + "_" + "boleto.pdf";
            String dirExport = @"C:\boleto\";
            String tempPath = dirExport + Path.DirectorySeparatorChar +
                        boleto.Banco + "_" + boleto.NossoNumero + ".pdf";

            if (File.Exists(tempPath))
            {
                try
                {
                    File.Delete(tempPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }
                
            }
            document = new Document(PageSize.A4);
            document.AddCreationDate();

            try
            {

                PdfWriter writer = PdfWriter.GetInstance(document, 
                    new FileStream(tempPath, FileMode.Create));

                document.Open();

                cb = writer.DirectContent; //getDirectContent();

                //gera template com o fundo do boleto
                string caminhoTemplate = @"../../img/";
                imgTitulo = Image.GetInstance(caminhoTemplate + template + ".gif");
                imgTitulo.ScaleToFit(IMAGEM_BOLETO_WIDTH, IMAGEM_BOLETO_HEIGHT);
                imgTitulo.SetAbsolutePosition(0, 0);

                imgTituloSup = Image.GetInstance(@"../../img/" + "template1" + ".gif"); //lau
                imgTituloSup.ScaleToFit(IMAGEM_BOLETO_WIDTH, IMAGEM_BOLETO_HEIGHT);
                imgTituloSup.SetAbsolutePosition(0, 0);

                //Pega a imagem do marketing
                if (boleto.ImagemMarketing != null)
                {

                    imgMarketing = Image.GetInstance(boleto.ImagemMarketing);
                }
                else
                { //caso o metodo nao esteja setado coloca uma imagem de um pixel no lugar

                    imgMarketing = Image.GetInstance(@"../../img/pixel.gif");
                }

                imgMarketing.ScaleToFit(IMAGEM_MARKETING_WIDTH, IMAGEM_MARKETING_HEIGHT);
                imgMarketing.SetAbsolutePosition(0, 0);

                imgBanco = Image.GetInstance(@"../../img/" + banco.getNumero() + ".gif");
                imgBanco.ScaleToFit(IMAGEM_BANCO_WIDTH, IMAGEM_BANCO_HEIGHT);
                imgBanco.SetAbsolutePosition(0, 0);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        /**
     * Adiciona um boleto na fila.
     * @author Fabio Souza
     */
        public void addBoleto(BoletoBean boleto, Banco banco)
        {

            try
            {

                tempImgMarketing = cb.CreateTemplate(IMAGEM_MARKETING_WIDTH, IMAGEM_MARKETING_HEIGHT);
                tempImgMarketing.AddImage(imgMarketing);

                tempImgBoleto = cb.CreateTemplate(IMAGEM_BOLETO_WIDTH, IMAGEM_BOLETO_HEIGHT);
                tempImgBoleto.AddImage(imgTitulo);

                //gera template com a imagem do logo do banco
                tempImgBanco = cb.CreateTemplate(IMAGEM_BANCO_WIDTH, IMAGEM_BANCO_HEIGHT);
                tempImgBanco.AddImage(imgBanco);

                //lau
                tempImgBoletoSup = cb.CreateTemplate(IMAGEM_BOLETO_WIDTH, IMAGEM_BOLETO_HEIGHT);
                tempImgBoletoSup.AddImage(imgTituloSup);

                float altura = 397; //412
                float altura1Via = 412;

                document.NewPage();

                cb.AddTemplate(tempImgMarketing, document.Left, document.Top - 340);

                //cb.AddTemplate(tempImgBoleto, document.Left, document.Top - 750); //original - comentado Lau
                cb.AddTemplate(tempImgBoleto, document.Left, document.Top - 765);
                //cb.AddTemplate(tempImgBanco, document.Left, document.Top - 486); // original - comentado Lau
                cb.AddTemplate(tempImgBanco, document.Left, document.Top - 501);

                cb.AddTemplate(tempImgBoletoSup, document.Left, document.Top - 320);//lau
                cb.AddTemplate(tempImgBanco, document.Left, document.Top - 7);//lau

                BaseFont bfTextoSimples = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
                BaseFont bfTextoCB = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.WINANSI, BaseFont.EMBEDDED);

                //inicio das descricoes do boleto
                //cb.BeginText();
                //cb.SetFontAndSize(bfTextoCB, 10);

                if (boleto.Descricoes != null)
                {
                    //inicio das descricoes do boleto - Lau 20/11/2017
                    cb.BeginText();
                    cb.SetFontAndSize(bfTextoCB, 10);

                    List<String> descricoes = boleto.Descricoes;
                    int i = 0;
                    foreach (String desc in descricoes)//(int i = 0; i < descricoes.L Size(); i++)
                    {

                        cb.SetTextMatrix(document.Left, document.Top - 70 + i * 15);
                        cb.ShowText(desc);
                        i++;
                    }

                    cb.EndText();
                }

                //fim descricoes
                //Lau - Primeira via
                cb.BeginText(); //Lau Inicio Numero do Banco
                cb.SetFontAndSize(bfTextoCB, 13);

                cb.SetTextMatrix(document.Left + 125, altura1Via + 391);

                cb.ShowText(banco.getNumero() + "-" + boleto.getDigitoCodigoBarras(banco.getNumero()));
                cb.EndText(); //Fim Numero do Banco

                cb.BeginText();
                cb.SetFontAndSize(bfTextoCB, 10);

                cb.SetTextMatrix(document.Left + 175, altura1Via + 391);
                cb.ShowText(banco.getLinhaDigitavel());
                cb.EndText();

                cb.BeginText();
                cb.SetFontAndSize(bfTextoSimples, 8);

                cb.SetTextMatrix(document.Left + 5, altura1Via + 368);
                cb.ShowText(boleto.LocalPagamento);

                cb.SetTextMatrix(document.Left + 5, altura1Via + 358);
                cb.ShowText(boleto.LocalPagamento2);

                cb.SetTextMatrix(document.Left + 425, altura1Via + 358);
                cb.ShowText(boleto.DataVencimento);

                cb.SetTextMatrix(document.Left + 3, altura1Via + 338);
                cb.ShowText(boleto.Cedente); //Lau imprime o cedente
                cb.SetTextMatrix(document.Left + 300, altura1Via + 338);
                cb.ShowText(boleto.getCpfCnpjCedenteFormatted()); //Lau imprime o CPF/CNPJ do cedente

                cb.SetTextMatrix(document.Left + 70, altura1Via + 176);
                cb.ShowText(boleto.NomeSacado + "     " + boleto.CpfSacado);
                cb.SetTextMatrix(document.Left + 70, altura1Via + 166);
                cb.ShowText(boleto.EnderecoSacado);

                cb.SetTextMatrix(document.Left + 70, altura1Via + 156);
                cb.ShowText(boleto.CepSacado + " " + boleto.BairroSacado + " - " + boleto.CidadeSacado + " " + boleto.UfSacado);

                cb.SetTextMatrix(document.Left + 410, altura1Via + 338);
                cb.ShowText(banco.getAgenciaCodCedenteFormatted());

                cb.SetTextMatrix(document.Left + 5, altura1Via + 317);
                cb.ShowText(boleto.DataDocumento);

                cb.SetTextMatrix(document.Left + 70, altura1Via + 317);
                cb.ShowText(boleto.NoDocumento);

                cb.SetTextMatrix(document.Left + 180, altura1Via + 317);
                cb.ShowText(boleto.EspecieDocumento);

                cb.SetTextMatrix(document.Left + 250, altura1Via + 317);
                cb.ShowText(boleto.Aceite);

                cb.SetTextMatrix(document.Left + 300, altura1Via + 317);
                cb.ShowText(boleto.DataProcessamento);

                cb.SetTextMatrix(document.Left + 410, altura1Via + 317);
                cb.ShowText(banco.getNossoNumeroFormatted());

                cb.SetTextMatrix(document.Left + 122, altura1Via + 294);
                cb.ShowText(banco.getCarteiraFormatted());

                cb.SetTextMatrix(document.Left + 200, altura1Via + 294);
                cb.ShowText("R$");

                cb.SetTextMatrix(document.Left + 430, altura1Via + 294);
                cb.ShowText(string.Format("{0:0,0.00}", Convert.ToDecimal(boleto.ValorBoleto.Replace('.', ',')))); 

                cb.SetTextMatrix(document.Left + 5, altura1Via + 272);
                cb.ShowText(boleto.Instrucao1);

                cb.SetTextMatrix(document.Left + 5, altura1Via + 262);
                cb.ShowText(boleto.Instrucao2);

                cb.SetTextMatrix(document.Left + 5, altura1Via + 252);
                cb.ShowText(boleto.Instrucao3);

                cb.SetTextMatrix(document.Left + 5, altura1Via + 242);
                cb.ShowText(boleto.Instrucao4);

                cb.SetTextMatrix(document.Left + 5, altura1Via + 232);
                cb.ShowText(boleto.Instrucao5);

                cb.SetTextMatrix(document.Left + 5, altura1Via + 202);
                cb.ShowText(boleto.Cedente);

                cb.EndText(); // Lau - Final da Primeira via


                cb.BeginText(); //Inicio Numero do Banco
                cb.SetFontAndSize(bfTextoCB, 13);

                cb.SetTextMatrix(document.Left + 125, altura - 87);

                cb.ShowText(banco.getNumero() + "-" + boleto.getDigitoCodigoBarras(banco.getNumero()));
                cb.EndText(); //Fim Numero do Banco

                cb.BeginText();
                cb.SetFontAndSize(bfTextoSimples, 8);

                cb.SetTextMatrix(document.Left + 50, altura + 23);
                cb.ShowText(boleto.Cedente); //imprime o cedente
                cb.SetTextMatrix(document.Left + 290, altura + 23);
                cb.ShowText("CPF/CNPJ: " + boleto.getCpfCnpjCedenteFormatted());

                cb.SetTextMatrix(document.Left + 5, altura);
                cb.ShowText(boleto.NomeSacado);

                cb.SetTextMatrix(document.Left + 230, altura);
                cb.ShowText(boleto.DataVencimento);

                cb.SetTextMatrix(document.Left + 400, altura);
                cb.ShowText(string.Format("{0:0,0.00}", Convert.ToDecimal(boleto.ValorBoleto.Replace('.', ','))));


                // ALTERADO POR GLADYSTON
                cb.SetTextMatrix(document.Left + 5, altura - 19);
                cb.ShowText(banco.getAgenciaCodCedenteFormatted());

                // ALTERADO POR GLADYSTON
                cb.SetTextMatrix(document.Left + 146, altura - 19);
                cb.ShowText(banco.getNossoNumeroFormatted());
                cb.EndText();

                cb.BeginText();
                cb.SetFontAndSize(bfTextoCB, 10);

                cb.SetTextMatrix(document.Left + 175, altura - 87);
                cb.ShowText(banco.getLinhaDigitavel());
                cb.EndText();

                cb.BeginText();
                cb.SetFontAndSize(bfTextoSimples, 8);

                cb.SetTextMatrix(document.Left + 5, altura - 111);
                cb.ShowText(boleto.LocalPagamento);

                cb.SetTextMatrix(document.Left + 5, altura - 121);
                cb.ShowText(boleto.LocalPagamento2);

                cb.SetTextMatrix(document.Left + 425, altura - 121);
                cb.ShowText(boleto.DataVencimento);

                cb.SetTextMatrix(document.Left + 5, altura - 141);
                cb.ShowText(boleto.Cedente);
                cb.SetTextMatrix(document.Left + 300, altura - 141);
                cb.ShowText(boleto.getCpfCnpjCedenteFormatted());

                // ALTERADO POR GLADYSTON
                cb.SetTextMatrix(document.Left + 410, altura - 141);
                cb.ShowText(banco.getAgenciaCodCedenteFormatted());

                cb.SetTextMatrix(document.Left + 5, altura - 162);
                cb.ShowText(boleto.DataDocumento);

                cb.SetTextMatrix(document.Left + 70, altura - 162);
                cb.ShowText(boleto.NoDocumento);

                cb.SetTextMatrix(document.Left + 180, altura - 162);
                cb.ShowText(boleto.EspecieDocumento);

                cb.SetTextMatrix(document.Left + 250, altura - 162);
                cb.ShowText(boleto.Aceite);

                cb.SetTextMatrix(document.Left + 300, altura - 162);
                cb.ShowText(boleto.DataProcessamento);

                // ALTERADO POR GLADYSTON
                cb.SetTextMatrix(document.Left + 410, altura - 162);
                cb.ShowText(banco.getNossoNumeroFormatted());

                // ALTERADO POR GLADYSTON
                cb.SetTextMatrix(document.Left + 122, altura - 185);
                cb.ShowText(banco.getCarteiraFormatted());

                cb.SetTextMatrix(document.Left + 200, altura - 185);
                cb.ShowText("R$");

                cb.SetTextMatrix(document.Left + 430, altura - 185);
                cb.ShowText(string.Format("{0:0,0.00}", Convert.ToDecimal(boleto.ValorBoleto.Replace('.', ','))));

                cb.SetTextMatrix(document.Left + 5, altura - 207);
                cb.ShowText(boleto.Instrucao1);

                cb.SetTextMatrix(document.Left + 5, altura - 217);
                cb.ShowText(boleto.Instrucao2);

                cb.SetTextMatrix(document.Left + 5, altura - 227);
                cb.ShowText(boleto.Instrucao3);

                cb.SetTextMatrix(document.Left + 5, altura - 237);
                cb.ShowText(boleto.Instrucao4);

                cb.SetTextMatrix(document.Left + 5, altura - 247);
                cb.ShowText(boleto.Instrucao5);

                cb.SetTextMatrix(document.Left + 5, altura - 277);
                cb.ShowText(boleto.Cedente);

                cb.SetTextMatrix(document.Left + 70, altura - 302);
                cb.ShowText(boleto.NomeSacado + "     " + boleto.CpfSacado);

                cb.SetTextMatrix(document.Left + 70, altura - 312);
                cb.ShowText(boleto.EnderecoSacado);

                cb.SetTextMatrix(document.Left + 70, altura - 322);
                cb.ShowText(boleto.CepSacado + " " + boleto.BairroSacado + " - " + boleto.CidadeSacado + " " + boleto.UfSacado);

                cb.EndText();

                try
                {
                    BarcodeInter25 code = new BarcodeInter25();
                    code.Code = banco.getCodigoBarras();
                    code.Extended = true;

                    code.TextAlignment = Element.ALIGN_LEFT;
                    code.BarHeight = 37.00f;
                    code.Font = null;
                    code.X = 0.73f;
                    code.N = 3;
                    PdfTemplate imgCB = code.CreateTemplateWithBarcode(cb, null, null);
                    cb.AddTemplate(imgCB, 37, 10);

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
                document.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        
    }
}
