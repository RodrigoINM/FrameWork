using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Framework.Core.FrameworkActions
{
    public class ServiceActions
    {
        public string NameFile { get; }
        public string directory { get; }
        public string RecentFile { get; }

        public class GetFile
        {
            public static string NameFile { get; private set; }

            public static string GetResourcePath(string file)
            {
                return $"{AppDomain.CurrentDomain.BaseDirectory}\\Downloads\\{file}";
            }

            public static void GetServiceCaminhoArquivo(string url, string nameFile)
            {
                using (WebClient client = new WebClient())
                {
                    string caminhoArquivo = GetResourcePath(nameFile);
                    client.DownloadFile(url, caminhoArquivo);
                }
            }

            public static string GetFileMostRecent(string caminho)
            {
                var directory = new DirectoryInfo(caminho);
				//var directory = new DirectoryInfo("C:\\Users\\TI\\Downloads");

				var RecentFile = directory.GetFiles("*.pdf")
                .OrderByDescending(f => f.LastWriteTime)
                .First();

                return NameFile = directory.ToString() + RecentFile.ToString();

            }
        }
    }
}
