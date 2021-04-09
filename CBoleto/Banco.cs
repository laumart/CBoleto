using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBoleto
{
    public interface Banco
    {
        /**
         * Recupera o codigo do banco
        */
        String getNumero();

        /**
         * Recupera o numero necessario para a geracao do codigo de barras
         */
        String getCodigoBarras();

        /**
         * Recupera a numeracao para a geracao da linha digitavel do boleto
         */
        String getLinhaDigitavel();

        /**
         * @Return Recupera a carteira no padrao especificado pelo banco
         * @author Gladyston Batista/Eac Software
         */
        String getCarteiraFormatted();

        /**
         * @Return Recupera a agencia/codigo cedente no padrao especificado pelo banco
         * @author Gladyston Batista/Eac Software
         */
        String getAgenciaCodCedenteFormatted();

        /**
         * @Return Recupera o nosso numero no padrao especificado pelo banco
         * @author Gladyston Batista/Eac Software
         */
        String getNossoNumeroFormatted();

    }
}
