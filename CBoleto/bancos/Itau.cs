using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBoleto.bancos
{
    class Itau : Banco
    {
        BoletoBean boleto;

        public String getNumero()
        {
            return "341";
        }

        public Itau(BoletoBean boleto)
        {
            this.boleto = boleto;
        }

        public int getDacNossoNumero()
        {
            int dac = 0;

            String campo = boleto.Agencia + boleto.ContaCorrente + boleto.Carteira + boleto.NossoNumero;

            int multiplicador = 1;
            int multiplicacao = 0;
            int soma_campo = 0;

            for (int i = 0; i < campo.Length; i++)
            {
                multiplicacao = Convert.ToInt32(campo.Substring(i, 1)) * multiplicador;

                if (multiplicacao >= 10)
                {
                    multiplicacao = Convert.ToInt32(Convert.ToString(multiplicacao).Substring(0, 1)) +
                                    Convert.ToInt32(Convert.ToString(multiplicacao).Substring(1));
                }
                soma_campo = soma_campo + multiplicacao;

                if (multiplicador == 2)
                    multiplicador = 1;
                else
                    multiplicador = 2;

            }

            dac = 10 - (soma_campo % 10);

            if (dac == 10)
                dac = 0;

            return dac;
        }

        private String getCampo1()
        {
            String campo = getNumero() + boleto.Moeda + boleto.Carteira + boleto.NossoNumero.Substring(0,2);
            return boleto.getDigitoCampo(campo, 2);
        }

        private String getCampo2()
        {
            String campo = boleto.NossoNumero.Substring(2) + getDacNossoNumero() + boleto.Agencia.Substring(0,3);

            return boleto.getDigitoCampo(campo, 1);
        }

        private String getCampo3()
        {
            String campo = boleto.Agencia.Substring(3) + boleto.ContaCorrente + boleto.DvContaCorrente + "000";

            return boleto.getDigitoCampo(campo, 1);
        }

        private String getCampo4()
        {
            String campo =  getNumero() + boleto.Moeda +
                boleto.getFatorVencimento() + boleto.getValorTitulo() + boleto.Carteira +
                boleto.NossoNumero + getDacNossoNumero() +
                boleto.Agencia + boleto.ContaCorrente + boleto.DvContaCorrente + "000";

            return boleto.getDigitoCodigoBarras(campo);
        }

        private String getCampo5()
        {
            String campo = boleto.getFatorVencimento() + boleto.getValorTitulo();
            return campo;
        }

        public String getCodigoBarras()
        {
            return getNumero() + boleto.Moeda + getCampo4() +
                    getCampo5() + boleto.Carteira +
                    boleto.NossoNumero + getDacNossoNumero() +
                    boleto.Agencia + boleto.ContaCorrente +
                    boleto.DvContaCorrente + "000";
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
            //return String.valueOf(Integer.parseInt(boleto.getNossoNumero()));
            return boleto.Carteira + '/' + boleto.NossoNumero + '-' + boleto.DvNossoNumero;
        }
    }
}
