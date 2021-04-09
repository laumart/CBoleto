using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CBoleto.principal;

namespace CBoleto
{
    class Program
    {
        static void Main(string[] args)
        {
            ImportaArquivo imp = new ImportaArquivo();
            imp.getArquivo();
            imp.fechaArquivo();
        }
    }
}
