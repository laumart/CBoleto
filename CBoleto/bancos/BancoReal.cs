using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBoleto.bancos
{
    class BancoReal : Banco
    {
        BoletoBean boleto;

        public BancoReal(BoletoBean boleto)
        {
            this.boleto = boleto;
        }

        /**
         * Metdodo responsavel por resgatar o numero do banco, coloque no return o codigo do seu banco
         */
        public String getNumero()
        {
            return "356";
        }

        /**
         * Metodo responsavel por fazer o calculo do digitao da cobranca.
         */
        public String getDigitao()
        {
            String campo = boleto.NossoNumero + boleto.Agencia + boleto.ContaCorrente;

            return boleto.getDigitoCampo(campo, 1).Substring(campo.Length);
        }

        /**
         * Metodo que monta o primeiro campo do codigo de barras
         * Este campo como os demais e feito a partir do da documentacao do banco
         * A documentacao do banco tem a estrutura de como monta cada campo, depois disso
         * é só concatenar os campos como no exemplo abaixo.
         */
        private String getCampo1()
        {
            String campo = getNumero() + boleto.Moeda + boleto.Agencia + boleto.ContaCorrente.Substring(0,1);

            return boleto.getDigitoCampo(campo, 2);
        }

        /**
         * ver documentacao do banco para saber qual a ordem deste campo
         */
        private String getCampo2()
        {
            String campo = boleto.ContaCorrente.Substring(1) + getDigitao() + boleto.NossoNumero.Substring(0,3);

            return boleto.getDigitoCampo(campo, 1);
        }

        /**
         * ver documentacao do banco para saber qual a ordem deste campo
         */
        private String getCampo3()
        {
            String campo = boleto.NossoNumero.Substring(3);

            return boleto.getDigitoCampo(campo, 1);
        }

        /**
         * ver documentacao do banco para saber qual a ordem deste campo
         */
        private String getCampo4()
        {
            String campo =  getNumero() + boleto.Moeda +
                boleto.getFatorVencimento() + boleto.getValorTitulo() + boleto.Agencia +
                boleto.ContaCorrente + getDigitao() + boleto.NossoNumero;

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
            return getNumero() + boleto.Moeda + getCampo4() +
                    boleto.getFatorVencimento() + boleto.getValorTitulo() + boleto.Agencia + boleto.ContaCorrente + 
                    getDigitao() + boleto.NossoNumero;
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
            return boleto.NossoNumero;
        }
    }
}
