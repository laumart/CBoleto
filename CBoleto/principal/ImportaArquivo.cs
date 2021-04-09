using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.util;
using CBoleto;

namespace CBoleto.principal
{
    public class ImportaArquivo
    {
        //File file;
        //Properties props;
        FileStream fis = null;

        //Metodo Importa Aruivo
        public void getArquivo()
        {
            string path = @"C:\boleto\";
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo f in di.GetFiles("*.txt"))
            {
                // Aqui pega o arquivo boleto.txt
                //String filename = arquivos[i];
                
                string filename = f.Name;
                carregaArquivo(path, filename);
                moverArquivo(path, filename);
            }
        }

        // Carrega os Arquivos
        public void carregaArquivo(String path, String filename)
        {
            BoletoBean bolBean = new BoletoBean();

            try
            {
                FileStream st = File.Open(path + filename, FileMode.Open);
                StreamReader str = new StreamReader(st);

                try
                {
                    string linha = str.ReadLine();
                    while (linha != null)
                    {
                        string[] dadosBoleto = linha.Split('|');
                        bolBean.Banco = dadosBoleto[0];
                        bolBean.Agencia = dadosBoleto[1];
                        bolBean.DvAgencia = dadosBoleto[2];
                        bolBean.ContaCorrente = dadosBoleto[3];
                        bolBean.DvContaCorrente = dadosBoleto[4];
                        //bolBean.Moeda = dadosBoleto[ 5];
                        bolBean.Carteira = dadosBoleto[6];
                        bolBean.NumConvenio = dadosBoleto[7];

                        if (bolBean.Banco == "151" ||
                            bolBean.Banco == "033")
                        {
                            bolBean.NossoNumero = dadosBoleto[8];
                        }
                        else if (bolBean.Banco == "341")
                        {

                            bolBean.NossoNumero = dadosBoleto[8];

                        }
                        else if (bolBean.Banco == "104")
                        {

                            bolBean.NossoNumero = dadosBoleto[8];

                        }
                        else if (bolBean.Banco == "001")
                        {
                            if (bolBean.NumConvenio.Length == 6 ||
                                bolBean.NumConvenio.Length == 4)
                            {

                                bolBean.NossoNumero = dadosBoleto[8];
                            }
                            else
                            {
                                bolBean.NossoNumero = dadosBoleto[8].Substring(8, 9);
                            }

                        }
                        else if (bolBean.Banco == "237")
                        {
                            bolBean.NossoNumero = dadosBoleto[8].Substring(2, 11);

                        }
                        else if (bolBean.Banco == "399" ||
                                 bolBean.Banco == "356")
                        {
                            bolBean.NossoNumero = dadosBoleto[8];
                        }
                        else if (bolBean.Banco == "409")
                        {
                            bolBean.NossoNumero = dadosBoleto[8];
                        }
                        else if (bolBean.Banco == "422")
                        {
                            bolBean.NossoNumero = dadosBoleto[8];
                        }

                        bolBean.DvNossoNumero = dadosBoleto[9];
                        bolBean.DataVencimento = dadosBoleto[10];
                        bolBean.DataDocumento = dadosBoleto[11];
                        bolBean.DataProcessamento = dadosBoleto[12];
                        bolBean.ValorBoleto = dadosBoleto[13];
                        bolBean.Caminho = dadosBoleto[14];
                        bolBean.TipoSaida = dadosBoleto[15];
                        bolBean.LocalPagamento = dadosBoleto[16];
                        bolBean.LocalPagamento2 = dadosBoleto[17];
                        bolBean.Cedente = dadosBoleto[18];
                        bolBean.CpfCnpjCedente = dadosBoleto[19];
                        bolBean.QtdMoeda = dadosBoleto[20];
                        bolBean.ValorMoeda = dadosBoleto[21];
                        //bolBean.Acrescimo = dadosBoleto[ 21];
                        bolBean.Instrucao1 = dadosBoleto[22];
                        bolBean.Instrucao2 = dadosBoleto[23];
                        bolBean.Instrucao3 = dadosBoleto[24];
                        bolBean.Instrucao4 = dadosBoleto[25];
                        bolBean.Instrucao5 = dadosBoleto[26];
                        bolBean.NomeSacado = dadosBoleto[27];
                        bolBean.CpfSacado = dadosBoleto[28];
                        bolBean.EnderecoSacado = dadosBoleto[29];
                        bolBean.CepSacado = dadosBoleto[30];
                        bolBean.BairroSacado = dadosBoleto[31];
                        bolBean.CidadeSacado = dadosBoleto[32];
                        bolBean.UfSacado = dadosBoleto[33];
                        bolBean.EspecieDocumento = dadosBoleto[34];
                        bolBean.Aceite = dadosBoleto[35];
                        bolBean.LinhaDigitavel = dadosBoleto[36];
                        //bolBean.CodigoBarras = dadosBoleto[ 37];
                        bolBean.CodCliente = dadosBoleto[38];

                        //Santander
                        if (bolBean.Banco == "033")
                        {
                            bolBean.Ios = "0";
                        }

                        bolBean.NoDocumento = dadosBoleto[40];

                        //Vector descricoes = new Vector();
                        //descricoes.add("Hospedagem I - teste descricao1 - R$ 39,90");
                        //descricoes.add("Manutencao - teste ricao2 - R$ 32,90");
                        //descricoes.add("Sistema - teste ssssde descricao3 - R$ 45,90");
                        //descricoes.add("Extra - teste de descricao4 - R$ 78,90");
                        //boletoBean.Descricoes(descricoes);

                        Boleto boleto = new Boleto();
                        String banco = null;

                        if (bolBean.Banco == "341")
                        {
                            boleto.addBoleto(bolBean, Boleto.ITAU);
                            banco = "itau";
                        }
                        else if (bolBean.Banco == "237")
                        {
                            boleto.addBoleto(bolBean, Boleto.BRADESCO);
                            banco = "bradesco";
                        }
                        else if (bolBean.Banco == "001")
                        {
                            boleto.addBoleto(bolBean, Boleto.BANCO_DO_BRASIL);
                            banco = "banco_brasil";
                        }
                        else if (bolBean.Banco == "353" ||
                                bolBean.Banco == "033")
                        {
                            boleto.addBoleto(bolBean, Boleto.SANTANDER);
                            banco = "santander";
                        }
                        else if (bolBean.Banco == "356")
                        {
                            boleto.addBoleto(bolBean, Boleto.BANCO_REAL);
                            banco = "real";
                        }
                        else if (bolBean.Banco == "399")
                        {
                            boleto.addBoleto(bolBean, Boleto.HSBC);
                            banco = "hsbc";
                        }
                        else if (bolBean.Banco == "151")
                        {
                            boleto.addBoleto(bolBean, Boleto.NOSSACAIXA);
                            banco = "nossa_caixa";
                        }
                        else if (bolBean.Banco == "104")
                        {
                            boleto.addBoleto(bolBean, Boleto.CAIXA_ECONOMICA);
                            banco = "caixa_economica";
                        }
                        else if (bolBean.Banco == "409")
                        {
                            boleto.addBoleto(bolBean, Boleto.UNIBANCO);
                            banco = "unibanco";
                        }
                        else if (bolBean.Banco == "422")
                        {
                            boleto.addBoleto(bolBean, Boleto.SAFRA);
                            banco = "safra";
                        }
                        //String dirExport = props.getProperty("dirExport");
                        String dirExport = @"C:\boleto\";
                        String dirExpCompleto;
                        dirExpCompleto = dirExport + Path.DirectorySeparatorChar +
                                    banco + "_" + bolBean.NossoNumero + ".pdf";

                        //boleto.writeToFile(dirExpCompleto, bolBean);

                        try
                        {
                            //File.Create(dirExpCompleto.ToString());
                            //PrinterSettings printerSettings = new PrinterSettings();
                            //PrintDocument printDocument = new PrintDocument();

                            //if (PrinterSettings.InstalledPrinters.Count > 0)
                            //{
                            //    if (printerSettings.IsDefaultPrinter)
                            //    {
                            //        printDocument.Print();
                            //    }
                            //}

                           
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        linha = str.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    st.Close();
                    str.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        //Move o arquivo para o diretorio de backup
        public void moverArquivo(String path, String filename)
        {

            String dirBackup = @"C:\boleto\";//props.getProperty("dirBackup");

            try
            {
                File.Move(path + filename, dirBackup + filename); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Fecha Arquivo
        public void fechaArquivo()
        {
            try
            {
                fis.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
