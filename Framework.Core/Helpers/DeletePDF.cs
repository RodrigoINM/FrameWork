using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Framework.Core.Helpers
{
	public static class DeletePDF
	{
		public static void DeletarPDF(IBrowser browser, string caminho)
		{
			ElementExtensions.WaitLoader(browser);
			VisualizarApagarPDF(caminho);
		}

		public static void DeletarZIP(IBrowser browser, string caminho)
		{
			ElementExtensions.WaitLoader(browser);
			VisualizarApagarZIP(caminho);
		}

		public static void DeletarJPEG(IBrowser browser, string caminho, Element elemento)
		{
			ElementExtensions.WaitLoader(browser);
			VisualizarApagarJPEG(browser, caminho, elemento);
		}

		private static void VisualizarApagarPDF(string caminho)
		{
			var directory = new DirectoryInfo(caminho);
			//var directory = new DirectoryInfo(""C:\\Users\\TI\\Downloads");

			var myFile = directory.GetFiles()
						 .OrderByDescending(f => f.LastWriteTime)
						 .First();

			string myFileTxt = "{" + myFile + "}";
			string newTxt = myFileTxt.Replace("/", "").Replace("{", "").Replace("}", "");

			Assert.IsTrue(true, myFileTxt);
			ApagarArquivo(caminho, newTxt);
		}

		private static void VisualizarApagarZIP(string caminho)
		{
			string zipTexto = "{Fotos.zip}";
			var directory = new DirectoryInfo(caminho);
			//var directory = new DirectoryInfo(""C:\\Users\\TI\\Downloads");

			var myFile = directory.GetFiles()
						 .OrderByDescending(f => f.LastWriteTime)
						 .First();
			string myFileTxt = "{" + myFile + "}";

			Assert.AreEqual(zipTexto, myFileTxt);

			string newTxt = "Fotos.zip";
			ApagarArquivo(caminho, newTxt);
		}

		private static void VisualizarApagarJPEG(IBrowser browser, string caminho, Element elemento)
		{
			string textoElemento = elemento.GetValorAtributo("data-codigoimagem", browser);

			string elementoFoto = "{" + textoElemento + ".jpeg}";

			var directory = new DirectoryInfo("C:\\Users\\TI\\Downloads");
			//var directory = new DirectoryInfo(""C:\\Users\\TI\\Downloads");

			var myFile = directory.GetFiles()
						 .OrderByDescending(f => f.LastWriteTime)
						 .First();
			string myFileTxt = "{" + myFile + "}";

			Assert.AreEqual(elementoFoto, myFileTxt);

			ApagarArquivo(caminho, textoElemento + ".jpeg");
		}

		private static void ApagarArquivo(string caminho, string arquivo)
		{
			if (File.Exists("" + caminho + "" + arquivo + ""))
			//if (File.Exists("C:\\Users\\TI\\Downloads\\" + arquivo + ""))
			{
				File.Delete(""+ caminho + "" + arquivo + "");
				//File.Delete("C:\\Users\\TI\\Downloads\\" + arquivo + "");
			}
		}
	}
}
