using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBoleto.bancos
{
    class Santander : Banco
    {
        BoletoBean boleto;

        public String D1 = "0";
        public String D2 = "0";

        /**
         * Metdodo responsavel por resgatar o numero do banco, coloque no return o codigo do seu banco
         */
        public String getNumero()
        {
            return "033";
        }

        /**
         * Método paticular do santander
         */
        public String getZero()
        {
            return "00";
        }

        private String getCampoLivre()
        {

            // alteração realizada por Jefferson Ricardo Zuchi
            // com base na versao 04/2009 do layout do banco
            //String campo = "9" + boleto.getCodCliente() + boleto.getNossoNumero() + boleto.getIOS() + boleto.getCarteira() ;
            String campo = "9" + boleto.NumConvenio + boleto.NossoNumero +
                       boleto.DvNossoNumero + boleto.Ios + boleto.Carteira ;

            return campo;
        }

        /**
         * Classe construtura, recebe como parametro a classe jboletobean
         */
        public Santander(BoletoBean boleto)
        {
            this.boleto = boleto;
        }

        /**
         * Metodo que monta o primeiro campo do codigo de barras
         * Este campo como os demais e feito a partir do da documentacao do banco
         * A documentacao do banco tem a estrutura de como monta cada campo, depois disso
         * Ã© sÃ³ concatenar os campos como no exemplo abaixo.
         */
        private String getCampo1()
        {
            String campo = getNumero() + boleto.Moeda + getCampoLivre().Substring(0, 5);

            return campo + boleto.getModulo10(campo);
        }

        /**
         * ver documentacao do banco para saber qual a ordem deste campo
         */
        private String getCampo2()
        {
            String campo = getCampoLivre().Substring(5, 10);

            return campo + boleto.getModulo10(campo);
        }

        /**
         * ver documentacao do banco para saber qual a ordem deste campo
         */
        private String getCampo3()
        {
            String campo = getCampoLivre().Substring(15, 10);
            return campo + boleto.getModulo10(campo);
        }

        /**
         * ver documentacao do banco para saber qual a ordem deste campo
         */
        private String getCampo4()
        {
            String campo =  getNumero() + boleto.Moeda +
                        boleto.getFatorVencimento() + boleto.getValorTitulo() + getCampoLivre() ;

            return boleto.getModulo11(campo, 9);
        }

        /**
         * ver documentacao do banco para saber qual a ordem deste campo
         */
        private String getCampo5()
        {
            String campo = boleto.getFatorVencimento() + boleto.getValorTitulo();
            return campo;
        }

        /**
         * Metodo para monta o desenho do codigo de barras
         * A ordem destes campos tambem variam de banco para banco, entao e so olhar na documentacao do seu banco
         * qual a ordem correta
         */
        public String getCodigoBarras()
        {

            return getNumero() + boleto.Moeda + getCampo4() + getCampo5() + getCampoLivre();

        }

        /**
         * Metodo que concatena os campo para formar a linha digitavel
         * E necessario tambem olhar a documentacao do banco para saber a ordem correta a linha digitavel
         */

        public String getLinhaDigitavel()
        {
            return getCampo1().Substring(0, 5) + "." + getCampo1().Substring(5) + "  " +
                    getCampo2().Substring(0, 5) + "." + getCampo2().Substring(5) + "  " +
                    getCampo3().Substring(0, 5) + "." + getCampo3().Substring(5) + "  " +
                    getCampo4() + "  " + getCampo5();
        }

        public String getCarteiraFormatted()
        {
            return boleto.Carteira;
        }

        
        public String getAgenciaCodCedenteFormatted()
        {
            return boleto.Agencia;
        }

        
        public String getNossoNumeroFormatted()
        {
            return boleto.NossoNumero;
        }
    }
}
