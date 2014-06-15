using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;

namespace TrabalhoThreads.Consumidores
{
    public class ComunidadorImpressora
    {
        public static void EnviarTextoParaImpressora(string nomeImpressora, string conteudo, string nomeArquivo)
        {
            var doc = new PrintDocument
            {
                PrintController = new StandardPrintController(),
                PrinterSettings = new PrinterSettings
                {
                    PrinterName = nomeImpressora,
                    PrintFileName = nomeArquivo,
                },
                DocumentName = nomeArquivo
            };
            doc.PrintPage += (sender, ev) => doc_PrintPage(ev, conteudo);
            doc.Print();
        }

        static void doc_PrintPage(PrintPageEventArgs ev, string conteudo)
        {
            var printFont = new Font("Arial", 10);
            ev.Graphics.DrawString(conteudo, printFont, Brushes.Black, 200, 40);
        }
    }
}