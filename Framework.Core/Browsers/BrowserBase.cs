using System;
using OpenQA.Selenium;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace Framework.Core.Browsers
{
    public abstract class BrowserBase : IBrowser
    {
        #region Fields and Constructor
        private IWebDriver Driver;
        #endregion

        #region Methods
        private void Dispose(bool disposing)
        {
            if (!disposing) return;

            Driver?.Dispose();
        }

        protected void SetupDriver<T>(T driver) where T : IWebDriver
        {
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Mata todos as instacias do Diver
        /// </summary>
        public void KillDriver()
        {
            Process.Start("taskkill", "/F /IM chromedriver.exe");
        }

        /// <summary>
        /// Mata todos os Browsers (chrome) abertos
        /// </summary>
        public void KillChrome()
        {
            Process.Start("taskkill", "/F /IM chrome.exe");
        }

        /// <summary>
        /// Abre o navegador
        /// </summary>
        public abstract void Iniciar();

        /// <summary>
        /// Retorna a url da página atual
        /// </summary>
        /// <returns></returns>
        public string UrlAtual()
        {
            return Driver.Url;
        }

        /// <summary>
        /// Direciona para um url
        /// </summary>
        /// <param name="url"></param>
        public void Abrir(string url)
        {
            Thread.Sleep(1000);
            Driver.Navigate().GoToUrl(url);
            PageLoad();
        }

        /// <summary>
        /// Fecha o navegador 
        /// </summary>
        public void Fechar()
        {
            Driver.Close();
        }

        /// <summary>
        /// Finaliza o driver do navegador
        /// </summary>
        public void Finalizar()
        {
            Driver.Quit();
        }

        /// <summary>
        /// Preenche um elemento do tipo input[type="text"]
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="dados"></param>
        public void InformarDados(Element elemento, string dados)
        {
            Driver.FindElement(elemento.ObterBy()).SendKeys(dados);
        }

        /// <summary>
        /// Recarrega a página
        /// </summary>
        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        /// <summary>
        /// Executa um history.back
        /// </summary>
        public void BackPage()
        {
            Driver.Navigate().Back();
        }

        public IWebDriver ObterDriver()
        {
            return Driver;
        }

        public bool PageSource(string dados)
        {
            return Driver.PageSource.Contains(dados);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string SwitchToGetText()
        {
            return Driver.SwitchTo().Alert().Text;
        }

        public void SwitchToLastWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        public void SwitchToFirstWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }

        public void CloseLastWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last()).Close();
        }

        public void CloseFirstWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.First()).Close();
        }

        public void PageLoad()
        {
            try
            {
                IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Driver, TimeSpan.FromSeconds(30));

                wait.Until(driver1 => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch
            {
                RefreshPage();
            }
            #endregion
        }
    }
}
