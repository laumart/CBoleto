using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBoleto.bancos
{
    class BancoBrasil : Banco
    {
        BoletoBean boleto;

        public String getNumero()
        {
            return "001";
        }

        public BancoBrasil(BoletoBean boleto)
        {
            this.boleto = boleto;
        }

        private String getCampoLivre()
        {
            String campo = null;

            //Incluido por Lau - Convenios de 4 e 6 digitos
            if (boleto.NumConvenio.Length == 4 ||
                boleto.NumConvenio.Length == 6)
            {

                campo = boleto.NossoNumero + boleto.Agencia + boleto.ContaCorrente + Convert.ToInt32(boleto.Carteira);
            }
            else if (boleto.NumConvenio.Length == 7)
            {
                campo = "000000" + boleto.NumConvenio + boleto.NossoNumero + boleto.Carteira;
            }
            return campo;
        }

        private String getCampo1()
        {
            String campo = getNumero() + boleto.Moeda + getCampoLivre().Substring(0,5);

            return boleto.getDigitoCampo(campo, 2);
        }

        private String getCampo2()
        {
            String campo = getCampoLivre().Substring(5,15);// + boleto.getAgencia();

            return boleto.getDigitoCampo(campo, 1);
        }

        private String getCampo3()
        {
            String campo = getCampoLivre().Substring(15);
            return boleto.getDigitoCampo(campo, 1);
        }

        private String getCampo4()
        {
            String campo =  getNumero() + Convert.ToString(boleto.Moeda) +
                boleto.getFatorVencimento() + boleto.getValorTitulo() + getCampoLivre();

            return boleto.getDigitoCodigoBarras(campo);
        }

        private String getCampo5()
        {
            String campo = boleto.getFatorVencimento() + boleto.getValorTitulo();
            return campo;
        }

        public String getCodigoBarras()
        {
            String campo =  getNumero() + Convert.ToString(boleto.Moeda) + getCampo4() +
                boleto.getFatorVencimento().ToString() + boleto.getValorTitulo() + getCampoLivre();

            return campo;
        }

        public String getLinhaDigitavel()
        {
            return getCampo1().Substring(0, 5) + "." + getCampo1().Substring(5) + "  " +
                    getCampo2().Substring(0, 5) + "." + getCampo2().Substring(5) + "  " +
                    getCampo3().Substring(0, 5) + "." + getCampo3().Substring(5) + "  " +
                    getCampo4() + "  " + getCampo5();
        }

        /**
         * Recupera a carteira no padrao especificado pelo banco
         * @author Gladyston Batista/Eac Software
         */
        public String getCarteiraFormatted()
        {
            return boleto.Carteira;
        }

        /**
         * Recupera a agencia / codigo cedente no padrao especificado pelo banco
         * @author Gladyston Batista/Eac Software
         */
        public String getAgenciaCodCedenteFormatted()
        {
            return boleto.Agencia + " / " + boleto.ContaCorrente + "-" + boleto.DvContaCorrente;
        }

        /**
         * Recupera o nossoNumero no padrao especificado pelo banco
         * @author Gladyston Batista/Eac Software
         */

        public String getNossoNumeroFormatted()
        {
            // Adicionado formatação do campo - Lau Martins
            //DefaultFormatter form;
            String nossoNumeroForm = null;
            try
            {
                if (boleto.NumConvenio.Length == 6 || boleto.NumConvenio.Length == 4)
                {
                    //form = new NumberFormatter(new DecimalFormat("00,000,000,000"));
                    nossoNumeroForm = Convert.ToString(boleto.NossoNumero) +
                                                             '-' + boleto.DvNossoNumero;

                }
                else if (boleto.NumConvenio.Length == 7)
                {
                    nossoNumeroForm = boleto.NumConvenio + boleto.NossoNumero; // + '-' + boleto.getDvNossoNumero();
                                                                                         //form = new NumberFormatter(new DecimalFormat("0,000,000,000"));
                                                                                         //nossoNumeroForm = String.valueOf(form.valueToString(Long.parseLong(boleto.getNossoNumero())) +
                                                                                         //                                          '-' + boleto.getDvNossoNumero());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return nossoNumeroForm;
            //return String.valueOf(Long.parseLong(boleto.getNossoNumero())); // return original - comentado Lau

        }




    }
}
