using System;
using System.Text;
using Framework.Core.FrameworkActions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Framework.Core.Interfaces;
using Framework.Core.Extensions.ElementExtensions;

namespace Framework.Core.Helpers
{
    public static class PDFHelpers
    {

        public static bool GetTextPDF(IBrowser browser, string textoPDF, string caminho)
        {
			ElementExtensions.WaitLoader(browser);
			PdfReader reader = new PdfReader(ServiceActions.GetFile.GetFileMostRecent(caminho));
            int qtdPagina = reader.NumberOfPages;
            Boolean achou = false;

            for (int i = 1; i <= qtdPagina; i++)
            {
                string texto = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
				string textoAtual = texto.Replace('\n', ' ');
				textoAtual = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(textoAtual));
                    if (textoAtual.ToLower().Contains(textoPDF.ToLower()))
                    {
                        achou = true;
                    }
                    else
                    {
                        achou = false;
                    }
            }
			reader.Close();
			return achou;
		}
    }
}
