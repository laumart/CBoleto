using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBoleto.bancos
{
    class CaixaEconomica : Banco
    {
        BoletoBean boleto;

        /**
         * Metdodo responsavel por resgatar o numero do banco, coloque no return o codigo do seu banco
         */
        public String getNumero()
        {
            return "104";
        }

        /**
         * Retorna o Campo livre
         */
        private String getCampoLivre()
        {
            //return boleto.getCarteira() + boleto.getNossoNumero() + boleto.getAgencia() +
            //boleto.getCodigoOperacao() + boleto.getCodigoFornecidoAgencia();
            /* Laudinei - no zim não tem campo separado para conta corrente e 
             * Codigo do Cedente. Por isso está sendo passado no numero do convenio
             * junto com o digito verificador sem o traço
             * 
             */
            String nn = boleto.NumConvenio;
            String campoLivre =  boleto.NumConvenio +
               boleto.NossoNumero.Substring(2, 3) +
               boleto.Carteira.Substring(0, 1) +
               boleto.NossoNumero.Substring(5, 3) +
               boleto.Carteira.Substring(1, 1) +
               boleto.NossoNumero.Substring(8, 9);

            campoLivre = campoLivre + boleto.getModulo11(campoLivre, 9, this);
            return campoLivre;
        }

        /**
         * Classe construtura, recebe como parametro a classe jboletobean
         * @param boleto
         */
        public CaixaEconomica(BoletoBean boleto)
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

            return boleto.getDigitoCampo(campo, 2);
        }

        /**
         * ver documentacao do banco para saber qual a ordem deste campo
         */
        private String getCampo2()
        {
            String campo = getCampoLivre().Substring(5, 10);

            return boleto.getDigitoCampo(campo, 1);
        }

        /**
         * ver documentacao do banco para saber qual a ordem deste campo
         */
        private String getCampo3()
        {
            String campo = getCampoLivre().Substring(15);

            return boleto.getDigitoCampo(campo, 1);
        }

        /**
         * ver documentacao do banco para saber qual a ordem deste campo
         */
        private String getCampo4()
        {
            String campo = getNumero() + boleto.Moeda +
                       boleto.getFatorVencimento() + boleto.getValorTitulo() +
                       getCampoLivre();

            return boleto.getDigitoCodigoBarras(campo);
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
            return getCampo1().Substring(0, 5) + "." + getCampo1().Substring(5) + "  " + getCampo2().Substring(0, 5) + "." + 
                   getCampo2().Substring(5) + "  " + getCampo3().Substring(0, 5) + "." + getCampo3().Substring(5) + "  " + 
                   getCampo4() + "  " + getCampo5();
        }

        /**
         * Recupera a carteira no padrao especificado pelo banco
         * @author Gladyston Batista/Eac Software
         */
        public String getCarteiraFormatted()
        {

            if ("1".Equals(boleto.Carteira.Substring(0, 1)))
            {
                return "RG";
            }
            else
            {
                return "SR";
            }

        }

        /**
         * Recupera a carteira no padrao especificado pelo banco
         * @author Gladyston Batista/Eac Software
         */
        public String getAgenciaCodCedenteFormatted()
        {

            /*
            Integer f1 = Integer.parseInt(boleto.getAgencia().substring(0, 4));
            Integer f2 = Integer.parseInt(boleto.getCodigoOperacao().substring(0, 3));
            Integer f3 = Integer.parseInt(boleto.getCodigoFornecidoAgencia());
            Integer f4 = Integer.parseInt(boleto.getDvCodigoFornecidoAgencia());

            return String.format("%04d.%03d.%08d-%01d", f1, f2, f3, f4);
            */

            return boleto.Agencia + " / " + boleto.NumConvenio.Substring(0, 6)
                    + "-" + boleto.NumConvenio.Substring(6, 1);
        }

        public String getNossoNumeroFormatted()
        {
            return boleto.NossoNumero + "-" + boleto.DvNossoNumero;
        }
    }
}
