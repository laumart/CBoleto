using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBoleto
{
    public class BoletoBean
    {

        private String banco;
        private String agencia;
        private String dvAgencia;
        private String contaCorrente;
        private String dvContaCorrente;
        private String moeda = "9";
        private String carteira;
        private String numConvenio;
        private String nossoNumero;
        private String dvNossoNumero;
        private String dataVencimento;
        private String dataDocumento;
        private String dataProcessamento;
        private String valorBoleto;
        private String caminho;
        private String tipoSaida;
        private String localPagamento;
        private String localPagamento2;
        private String cedente;
        private String cpfCnpjCedente;
        private String qtdMoeda;
        private String valorMoeda;
        private String acrescimo;
        private String instrucao1;
        private String instrucao2;
        private String instrucao3;
        private String instrucao4;
        private String instrucao5;
        private String nomeSacado;
        private String cpfSacado;
        private String enderecoSacado;
        private String cepSacado;
        private String bairroSacado;
        private String cidadeSacado;
        private String ufSacado;
        private String especieDocumento;
        private String aceite;
        private String linhaDigitavel;
        private String codigoBarras;
        private String codCliente;
        private String ios;
        private String noDocumento;
        private String codigoOperacao;
        private String codigoFornecidoAgencia;
        private String dvCodigoFornecidoAgencia;
        private String imagemMarketing;
        private List<String> descricoes;

        public string NumConvenio
        {
            get { return this.numConvenio; }
            set { this.numConvenio = value; }
        }

        public string NossoNumero
        {
            get
            {
                return nossoNumero;
            }

            set
            {
                nossoNumero = value;
            }
        }

        public string Agencia
        {
            get
            {
                return agencia;
            }

            set
            {
                agencia = value;
            }
        }

        public string ContaCorrente
        {
            get
            {
                return contaCorrente;
            }

            set
            {
                contaCorrente = value;
            }
        }

        public string Carteira
        {
            get
            {
                return carteira;
            }

            set
            {
                carteira = value;
            }
        }

        public string Moeda
        {
            get
            {
                return moeda;
            }

            set
            {
                moeda = value;
            }
        }

        public string ValorBoleto
        {
            get
            {
                return valorBoleto;
            }

            set
            {
                valorBoleto = value;
            }
        }

        public string DvContaCorrente
        {
            get
            {
                return dvContaCorrente;
            }

            set
            {
                dvContaCorrente = value;
            }
        }

        public string DvNossoNumero
        {
            get
            {
                return dvNossoNumero;
            }

            set
            {
                dvNossoNumero = value;
            }
        }

        public string ImagemMarketing
        {
            get
            {
                return imagemMarketing;
            }

            set
            {
                imagemMarketing = value;
            }
        }

        public string CodigoBarras
        {
            get
            {
                return codigoBarras;
            }

            set
            {
                codigoBarras = value;
            }
        }

        public string LinhaDigitavel
        {
            get
            {
                return linhaDigitavel;
            }

            set
            {
                linhaDigitavel = value;
            }
        }

        public List<string> Descricoes
        {
            get
            {
                return descricoes;
            }

            set
            {
                descricoes = value;
            }
        }

        public string LocalPagamento
        {
            get
            {
                return localPagamento;
            }

            set
            {
                localPagamento = value;
            }
        }

        public string LocalPagamento2
        {
            get
            {
                return localPagamento2;
            }

            set
            {
                localPagamento2 = value;
            }
        }

        public string DataVencimento
        {
            get
            {
                return dataVencimento;
            }

            set
            {
                dataVencimento = value;
            }
        }

        public string Cedente
        {
            get
            {
                return cedente;
            }

            set
            {
                cedente = value;
            }
        }

        public string CpfCnpjCedente
        {
            get
            {
                return cpfCnpjCedente;
            }

            set
            {
                cpfCnpjCedente = value;
            }
        }

        public string NomeSacado
        {
            get
            {
                return nomeSacado;
            }

            set
            {
                nomeSacado = value;
            }
        }

        public string CpfSacado
        {
            get
            {
                return cpfSacado;
            }

            set
            {
                cpfSacado = value;
            }
        }

        public string EnderecoSacado
        {
            get
            {
                return enderecoSacado;
            }

            set
            {
                enderecoSacado = value;
            }
        }

        public string CepSacado
        {
            get
            {
                return cepSacado;
            }

            set
            {
                cepSacado = value;
            }
        }

        public string BairroSacado
        {
            get
            {
                return bairroSacado;
            }

            set
            {
                bairroSacado = value;
            }
        }

        public string CidadeSacado
        {
            get
            {
                return cidadeSacado;
            }

            set
            {
                cidadeSacado = value;
            }
        }

        public string UfSacado
        {
            get
            {
                return ufSacado;
            }

            set
            {
                ufSacado = value;
            }
        }

        public string EspecieDocumento
        {
            get
            {
                return especieDocumento;
            }

            set
            {
                especieDocumento = value;
            }
        }

        public string NoDocumento
        {
            get
            {
                return noDocumento;
            }

            set
            {
                noDocumento = value;
            }
        }

        public string DataDocumento
        {
            get
            {
                return dataDocumento;
            }

            set
            {
                dataDocumento = value;
            }
        }

        public string Aceite
        {
            get
            {
                return aceite;
            }

            set
            {
                aceite = value;
            }
        }

        public string DataProcessamento
        {
            get
            {
                return dataProcessamento;
            }

            set
            {
                dataProcessamento = value;
            }
        }

        public string Instrucao1
        {
            get
            {
                return instrucao1;
            }

            set
            {
                instrucao1 = value;
            }
        }

        public string Instrucao2
        {
            get
            {
                return instrucao2;
            }

            set
            {
                instrucao2 = value;
            }
        }

        public string Instrucao3
        {
            get
            {
                return instrucao3;
            }

            set
            {
                instrucao3 = value;
            }
        }

        public string Instrucao4
        {
            get
            {
                return instrucao4;
            }

            set
            {
                instrucao4 = value;
            }
        }

        public string Instrucao5
        {
            get
            {
                return instrucao5;
            }

            set
            {
                instrucao5 = value;
            }
        }

        public string Banco
        {
            get
            {
                return banco;
            }

            set
            {
                banco = value;
            }
        }

        public string DvAgencia
        {
            get
            {
                return dvAgencia;
            }

            set
            {
                dvAgencia = value;
            }
        }

        public string Caminho
        {
            get
            {
                return caminho;
            }

            set
            {
                caminho = value;
            }
        }

        public string TipoSaida
        {
            get
            {
                return tipoSaida;
            }

            set
            {
                tipoSaida = value;
            }
        }

        public string QtdMoeda
        {
            get
            {
                return qtdMoeda;
            }

            set
            {
                qtdMoeda = value;
            }
        }

        public string ValorMoeda
        {
            get
            {
                return valorMoeda;
            }

            set
            {
                valorMoeda = value;
            }
        }

        public string CodCliente
        {
            get
            {
                return codCliente;
            }

            set
            {
                codCliente = value;
            }
        }

        public string Ios
        {
            get
            {
                return ios;
            }

            set
            {
                ios = value;
            }
        }

        public string DvCodigoFornecidoAgencia
        {
            get
            {
                return dvCodigoFornecidoAgencia;
            }

            set
            {
                dvCodigoFornecidoAgencia = value;
            }
        }

        public string CodigoFornecidoAgencia
        {
            get
            {
                return codigoFornecidoAgencia;
            }

            set
            {
                codigoFornecidoAgencia = value;
            }
        }

        public string CodigoOperacao
        {
            get
            {
                return codigoOperacao;
            }

            set
            {
                codigoOperacao = value;
            }
        }

       
        public BoletoBean()
        {
        }

        public long getFatorVencimento()
        {

            String[] data = DataVencimento.Split('/');
				String dia = data[0];
				String mes = data[1];
				String ano = data[2];

				DateTime dataBase = new DateTime(1997, 10, 7); 
				DateTime vencimento = new DateTime(Convert.ToInt32(ano), Convert.ToInt32(mes) - 1, Convert.ToInt32(dia));
				TimeSpan ts = vencimento.Subtract(dataBase);

				long diferencaDias = ts.Ticks / (24 * 60  * 60);
				diferencaDias = diferencaDias / 10000000;
				            
            return diferencaDias;
        }

        /**
         * Seta o nosso numero.
         * @param nossoNumero
         * @param qtdDigitos - Quantidade de digitos que contem o campo nosso numero referente ao seu banco
         * Seta o nosso numero.
         */
        public void setNossoNumero(String nossoNumero, int qtdDigitos)
        {
            String zeros = "0000000000000000000000000000000000000000";
            int rest = qtdDigitos - nossoNumero.Length;

            nossoNumero = (zeros.Substring(0, rest) + nossoNumero);
        }

        /**
        * Modulo 10 (212121)
        * Retorna o digito verificador de cada campo da linha digitavel. Voce deve passar como parametro a string do campo conforme o seu banco.
        * @return Retorna o digito verificador de cada campo da linha digitavel. Voce deve passar como parametro a string do campo conforme o seu banco.
        */
        public String getDigitoCampo(String campo, int mult)
        {
            //Esta rotina faz o calcula 212121

            int multiplicador = mult;
            int multiplicacao = 0;
            int soma_campo = 0;

            for (int i = 0; i < campo.Length; i++)
            {
                multiplicacao = Convert.ToInt32(campo.Substring(i, 1)) * multiplicador;

                if (multiplicacao >= 10)
                {
                    multiplicacao = Convert.ToInt32(Convert.ToString(multiplicacao).Substring(0, 1)) + Convert.ToInt32(Convert.ToString(multiplicacao).Substring(1));
                }

                soma_campo = soma_campo + multiplicacao;

                // ALTERADO POR VITOR MOTTA PARA SUBSTITUIR O COMENTARIO ABAIXO
                // valores assumidos: 212121...
                multiplicador = (multiplicador % 2) + 1;
                /*
                if (multiplicador == 2)
                multiplicador = 1;
                else
                multiplicador = 2;
                 */

            }
            int dac = 10 - (soma_campo % 10);

            if (dac == 10)
            {
                dac = 0;
            }

            campo = campo + Convert.ToString(dac);

            return campo;
        }

        /**
        * Retorna o quinto campo da linha digitavel do codigo
        * @return Retorna o quinto campo da linha digitavel do codigo
        */
        public String getValorTitulo()
        {
            String zeros = "0000000000";
            String valor = "";
            
            valor = valorBoleto.Replace(",", "").Replace(".", "");
            String valorTitulo = zeros.Substring(0, zeros.Length - valor.Length) + valor;

            return valorTitulo;
        }

        public String getDigitoCodigoBarras(String campo)
        {
            //Esta rotina faz o calcula no modulo 11 - 23456789
            int digito = 0;
            int multiplicador = 4;
            long multiplicacao = 0;
            long soma_campo = 0;

            for (int i = 0; i < campo.Length; i++)
            {
                try
                {
                    digito = Convert.ToInt32(campo.Substring(i, 1));
                    multiplicacao = digito * multiplicador;

                    soma_campo = soma_campo + multiplicacao;

                    // ALTERADO POR VITOR MOTTA PARA SUBSTITUIR O COMENTARIO ABAIXO
                    // valores assumidos: 43298765432987...
                    multiplicador = ((multiplicador + 5) % 8) + 2;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
                /*
                if (multiplicador == 4)
                multiplicador = 3;

                else if (multiplicador == 3)
                multiplicador = 2;

                else if (multiplicador == 2)
                multiplicador = 9;

                else if (multiplicador == 9)
                multiplicador = 8;

                else if (multiplicador == 8)
                multiplicador = 7;

                else if (multiplicador == 7)
                multiplicador = 6;

                else if (multiplicador == 6)
                multiplicador = 5;

                else if (multiplicador == 5)
                multiplicador = 4;
                 */
            }

            int resto = (int)(soma_campo % 11);
            int dac = 11 - resto; // - (soma_campo % 11);

            if (dac == 0 || dac == 1 || dac > 9)
            {
                //if (resto == 0 || resto == 1 || resto == 10) {
                //dac = 1;
                dac = 1;
            }

            if ("104".Equals(campo))
            {
                dac = 0;
            }

            campo = Convert.ToString(dac);

            return campo;
        }

        public String getCpfCnpjCedenteFormatted()
        {

            if (CpfCnpjCedente.Length == 14)
            {
                try
                {
                    //MaskFormatter mf = new MaskFormatter("AA.AAA.AAA/AAAA-AA");
                    //mf.setValueContainsLiteralCharacters(false);
                    return Convert.ToUInt64(CpfCnpjCedente).ToString(@"00\.000\.000\/0000\-00");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }
            }

            if (CpfCnpjCedente.Length == 11)
            {
                try
                {
                    //MaskFormatter mf = new MaskFormatter("AAA.AAA.AAA-AA");
                    //mf.setValueContainsLiteralCharacters(false);
                    return Convert.ToUInt64(CpfCnpjCedente).ToString(@"000\.000\.000\-00");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }
            }
            return cpfCnpjCedente;
        }

        public String getModulo10(String campo)
        {

            int multiplicador = 2;
            int multiplicacao = 0;
            int soma_campo = 0;

            for (int i = campo.Length; i > 0; i--)
            {
                multiplicacao = Convert.ToInt32(campo.Substring(i - 1, 1)) * multiplicador;

                if (multiplicacao >= 10)
                {
                    multiplicacao = Convert.ToInt32(Convert.ToString(multiplicacao).Substring(0, 1)) +
                                    Convert.ToInt32(Convert.ToString(multiplicacao).Substring(1, 1));
                }
                soma_campo = soma_campo + multiplicacao;

                if (multiplicador == 1)
                {
                    multiplicador = 2;
                }
                else
                {
                    multiplicador = 1;
                }
            }
            int dac = 10 - (soma_campo % 10);

            if (dac > 9)
            {
                dac = 0;
            }

            return Convert.ToString(dac);
        }

        public String getModulo11(String campo, int type)
        {
            //Modulo 11 - 234567   (type = 7)
            //Modulo 11 - 23456789 (type = 9)

            int multiplicador = 2;
            int multiplicacao = 0;
            int soma_campo = 0;

            for (int i = campo.Length; i > 0; i--)
            {
                multiplicacao = Convert.ToInt32(campo.Substring(i - 1, 1)) * multiplicador;

                soma_campo = soma_campo + multiplicacao;

                multiplicador++;
                if (multiplicador > 7 && type == 7)
                {
                    multiplicador = 2;
                }
                else if (multiplicador > 9 && type == 9)
                {
                    multiplicador = 2;
                }
            }

            int dac = 11 - (soma_campo % 11);

            if (dac > 9 && type == 7)
            {
                dac = 0;
            }
            else if ((dac == 0 || dac == 1 || dac > 9) && type == 9)
            {
                dac = 1;
            }

            return Convert.ToString(dac);
        }

        public String getModulo11(String campo, int type, Banco banco)
        {
            //Modulo 11 - 234567   (type = 7)
            //Modulo 11 - 23456789 (type = 9)

            int multiplicador = 2;
            int multiplicacao = 0;
            int soma_campo = 0;

            for (int i = campo.Length; i > 0; i--)
            {
                multiplicacao = Convert.ToInt32(campo.Substring(i - 1, 1)) * multiplicador;

                soma_campo = soma_campo + multiplicacao;

                multiplicador++;
                if (multiplicador > 7 && type == 7)
                {
                    multiplicador = 2;
                }
                else if (multiplicador > 9 && type == 9)
                {
                    multiplicador = 2;
                }
            }

            int dac = 11 - (soma_campo % 11);

            if (dac > 9 && type == 7)
            {
                dac = 0;
            }
            else if (((dac == 0 || dac == 1 || dac > 9) && type == 9)
                                 && !"104".Equals(banco.getNumero()))
            {
                dac = 1;
            }
            else if (dac > 9 && "104".Equals(banco.getNumero()))
            {
                dac = 0;
            }

            return Convert.ToString(dac);
        }

        public String completaZerosEsquerda(String str, int qtdZeros)
        {
            String zeros = "000000000000000000000000000000000000000";
            int dif = qtdZeros - str.Length;

            return zeros.Substring(0, dif) + str;
        }
    }

}
