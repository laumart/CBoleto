using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBoleto.control;

namespace CBoleto.bancos
{
    class Bradesco : Banco
    {
        BoletoBean boleto;

        public String getNumero()
        {
            return "237";
        }

        public Bradesco(BoletoBean boleto)
        {
            this.boleto = boleto;
        }

        private String getCampoLivre()
        {

            String campo = boleto.Agencia + boleto.Carteira + boleto.NossoNumero +
                       boleto.ContaCorrente + "0";

            return campo;
        }

        private String getCampo1()
        {
            String campo = getNumero() + boleto.Moeda + getCampoLivre().Substring(0,5);

            return boleto.getDigitoCampo(campo, 2);
        }

        private String getCampo2()
        {
            String campo = getCampoLivre().Substring(5,10);

            return boleto.getDigitoCampo(campo, 1);
        }

        private String getCampo3()
        {
            String campo = getCampoLivre().Substring(15,10);

            return boleto.getDigitoCampo(campo, 1);
        }

        private String getCampo4()
        {
            String campo =  getNumero() +
                boleto.Moeda +
                boleto.getFatorVencimento() +
                boleto.getValorTitulo() +
                boleto.Agencia +
                boleto.Carteira +
                boleto.NossoNumero +
                boleto.ContaCorrente + "0";

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
                boleto.getFatorVencimento() + boleto.getValorTitulo() + boleto.Agencia +
                boleto.Carteira + boleto.NossoNumero + boleto.ContaCorrente + "0";

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
            return Convert.ToString(boleto.Carteira + "/" + boleto.NossoNumero +
                    "-" + boleto.DvNossoNumero);
        }
    }
}
