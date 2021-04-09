using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBoleto.control;
using CBoleto.bancos;
using System.IO;

namespace CBoleto
{
    public class Boleto
    {
        public const int BANCO_DO_BRASIL = 0;
        public const int BRADESCO = 1;
        public const int ITAU = 2;
        public const int BANCO_REAL = 3;
        public const int CAIXA_ECONOMICA = 4;
        public const int UNIBANCO = 5;
        public const int HSBC = 6;
        public const int NOSSACAIXA = 7;
        public const int SANTANDER = 8;
        public const int SAFRA = 9;
        private PDFGenerator generator;

        /**
         * Metodo responsavel por adicionar um boleto na fila para a geracao e identificando o seu respectivo banco
         */
        public void addBoleto(BoletoBean boleto, int banco)
        {

            Banco bancoBean = null;

            if (banco == Boleto.BANCO_DO_BRASIL)
            {

                bancoBean = new BancoBrasil(boleto);
            }
            else if (banco == Boleto.BRADESCO)
            {

                bancoBean = new Bradesco(boleto);
            }
            else if (banco == Boleto.ITAU)
            {

                bancoBean = new Itau(boleto);
            }
            else if (banco == Boleto.BANCO_REAL)
            {

                //bancoBean = new BancoReal(boleto);
            }
            else if (banco == Boleto.CAIXA_ECONOMICA)
            {

                bancoBean = new CaixaEconomica(boleto);
            }
            else if (banco == Boleto.UNIBANCO)
            {

                //bancoBean = new Unibanco(boleto);
            }
            else if (banco == Boleto.HSBC)
            {

                //bancoBean = new Hsbc(boleto);
            }
            else if (banco == Boleto.NOSSACAIXA)
            {

                //bancoBean = new NossaCaixa(boleto);
            }
            else if (banco == Boleto.SANTANDER)
            {

                bancoBean = new Santander(boleto);
            }
            else if (banco == Boleto.SAFRA)
            {

                //bancoBean = new Safra(boleto);
            }

            /**
             * Alterado por Gladyston/EAC Software
             * seta as inf no objeto boleto p/ serem acessadas atraves do main
             */
            boleto.CodigoBarras = bancoBean.getCodigoBarras();
            boleto.LinhaDigitavel = bancoBean.getLinhaDigitavel();


            /**
             * Alterado pela Fly solution
             * Caso queira colocar uma imagem de fundo personalizada para um banco em especifico
             * é só criar a imagem dentro da pasta img e passar como parametro conforme
             * mostrado abaixo.
             * A imagem padrão para todos os boletos é a template.png
             * Ainda não temos nenhuma personalizacao
             */
            if (generator == null)
            {

                if (banco == Boleto.NOSSACAIXA)
                {

                    generator = new PDFGenerator("template", boleto, bancoBean);
                }
                else
                {

                    generator = new PDFGenerator("template", boleto, bancoBean);
                }
            }

            generator.addBoleto(boleto, bancoBean);
        }

        /**
         * Metodo que cria o arquivo loca no disco
         */
        public void writeToFile(String path, BoletoBean boleto)
        {
            String pathOrigem = AppDomain.CurrentDomain.BaseDirectory + boleto.Banco + "_" +
                                                    boleto.NossoNumero + "_" + "boleto.pdf";

            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }
            }

            try
            {
                File.Copy(pathOrigem, path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }
        
    }
}
