using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBoleto.bancos
{
    class Sicredi : Banco
    {
        BoletoBean boleto;

        
        public String getNumero()
        {
            return "748";
        }

        public Sicredi(BoletoBean boleto)
        {
            this.boleto = boleto;

        }

        private String getCampo1()
        {
            String campo = getNumero() +
                boleto.Moeda +
                getCampoLivre().Substring(0, 5);

            return boleto.getDigitoCampo(campo, 2);
        }

        private String getCampo2()
        {
            String campo = getCampoLivre().Substring(5, 10);

            return boleto.getDigitoCampo(campo, 1);
        }

        private String getCampo3()
        {
            String campo = getCampoLivre().Substring(15, 10);

            return boleto.getDigitoCampo(campo, 1);
        }

        private String getCampo4()
        {
            String campo = getNumero() +
                boleto.Moeda +
                boleto.getFatorVencimento() +
                boleto.getValorTitulo() +
                getCampoLivre();

            return boleto.getDigitoCodigoBarras(campo);
        }

        private String getCampo5()
        {
            String campo = boleto.getFatorVencimento() +
                boleto.getValorTitulo();
            return campo;
        }

        public String getCodigoBarras()
        {
            String campo1 = getNumero();
            String campo2 = boleto.Moeda;
            String campo3 = getCampo4();
            String campo4 = Convert.ToString(boleto.getFatorVencimento());
            String campo5 = boleto.getValorTitulo();
            String campo6 = getCampoLivre();

            String campo = campo1 + campo2 + campo3 + campo4 + campo5 + campo6;
            return campo;
        }

        public String getLinhaDigitavel()
        {
            String campo = "";
            String campo1 = getCampo1();
            String campo2 = getCampo2();
            String campo3 = getCampo3();
            String campo4 = getCampo4();
            String campo5 = getCampo5();
            campo = campo1.Substring(0, 5) + "." +
                    campo1.Substring(5) + "  " +
                    campo2.Substring(0, 5) + "." +
                    campo2.Substring(5) + "  " +
                    campo3.Substring(0, 5) + "." +
                    campo3.Substring(5) + "  " +
                    campo4 + "  " + campo5;
            return campo;
        }

        public String getCampoLivre()
        {
            String retorno = "31" + boleto.NossoNumero + boleto.completaZerosEsquerda(boleto.Agencia, 4) + "05" + 
                                    boleto.Cedente + "10";
            retorno = retorno + getDigitoCampoLivre(retorno, 9);
            return retorno;
        }

        // Esta função tive que mudar por este motivo vriei outra com outro nome
        // mas acho teria que ir para a classe JBoletoBean
        public String getDigitoCampoLivre(String campo, int peso)
        {
            //Esta rotina fa o calcula no modulo 11 - 23456789

            int multiplicador = peso;
            int multiplicacao = 0;
            int soma_campo = 0;

            for (int i = 0; i < campo.Length; i++)
            {
                multiplicacao = Convert.ToInt32(campo.Substring(i, 1)) * multiplicador;

                soma_campo = soma_campo + multiplicacao;

                if (multiplicador == 4)
                {
                    multiplicador = 3;
                }
                else if (multiplicador == 3)
                {
                    multiplicador = 2;
                }
                else if (multiplicador == 2)
                {
                    multiplicador = 9;
                }
                else if (multiplicador == 9)
                {
                    multiplicador = 8;
                }
                else if (multiplicador == 8)
                {
                    multiplicador = 7;
                }
                else if (multiplicador == 7)
                {
                    multiplicador = 6;
                }
                else if (multiplicador == 6)
                {
                    multiplicador = 5;
                }
                else if (multiplicador == 5)
                {
                    multiplicador = 4;
                }
            }

            int dac = (soma_campo % 11);
            if (dac <= 1)
            {
                dac = 0;
            }
            else
            {
                dac = 11 - dac;
                if (dac == 0 || dac == 1 || dac == 10 || dac == 11)
                {
                    dac = 1;
                }

            }

            campo = Convert.ToString(dac);

            return campo;
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
