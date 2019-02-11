using System;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Framework.Core.FrameworkActions;
using Framework.Core.Exceptions;
using System.Diagnostics;

namespace Framework.Core.Extensions.ElementExtensions
{
    public static class ElementExtensions
    {
        private static int SEGUNDOS_TIMEOUT_ELEMENTO = 120;

        public static bool IsClickable(this Element elemento, IBrowser browser)
        {
            var iWebElement = BrowserHelpers.ObterIWebElement(browser, elemento);
            browser.ObterDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SEGUNDOS_TIMEOUT_ELEMENTO);
            //elemento.EsperarElemento(browser);
//            var wait = new WebDriverWait(browser.ObterDriver(), TimeSpan.FromSeconds(SEGUNDOS_TIMEOUT_ELEMENTO));
//            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elemento.ObterBy()));

            return iWebElement.Displayed;
        }

        public static void ClickIFrame(this Element iFrame, IBrowser browser, Element elemento)
        {
			var wait = new WebDriverWait(browser.ObterDriver(), TimeSpan.FromSeconds(SEGUNDOS_TIMEOUT_ELEMENTO));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(iFrame.ObterBy()));

            elemento.EsperarElemento(browser);
			MouseActions.ClickATM(browser, elemento);
		}

		public static void AnexarArquivoIFrame(this Element iFrame, IBrowser browser, Element elemento, string dados)
		{
			var wait = new WebDriverWait(browser.ObterDriver(), TimeSpan.FromSeconds(SEGUNDOS_TIMEOUT_ELEMENTO));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(iFrame.ObterBy()));

            AutomatedActions.SendDataATM(browser, elemento, dados);
		}

		public static void ApagarEditarDados(this Element elemento, string dados, IBrowser browser)
        {
			elemento.EsperarElemento(browser);

			if (elemento.IsClickable(browser))
                MouseActions.ClickATM(browser, elemento);

				AutomatedActions.SendDataATM(browser, elemento, Keys.Backspace);
				elemento.Esperar(browser, 10);
				AutomatedActions.SendDataATM(browser, elemento, Keys.Backspace);
				AutomatedActions.SendDataATM(browser, elemento, dados);
				AutomatedActions.SendDataATM(browser, elemento, Keys.Enter);
        }

        public static void ClicarEsperarElemento(this Element elemento, IBrowser browser)
        {
            if (elemento.IsClickable(browser))
                MouseActions.ClickATM(browser, elemento);

            else
                throw new ElementoNaoEncontrado("Elemento não foi encontrado ou não está clicável.");
        }

        public static void ClicarInteligente(this Element elemento, IBrowser browser)
        {
            var sucesso = false;
            var execucoes = 3;

            while (!sucesso && execucoes > 0)
            {
                try
                {
                    execucoes--;
                    BrowserHelpers.ObterIWebElement(browser, elemento).Click();
                    sucesso = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(SEGUNDOS_TIMEOUT_ELEMENTO);

                    if (execucoes == 0)
                        throw new ElementoNaoEncontrado($"O elemento {elemento} não foi encontrado.");
                }
            }
        }

        public static void Esperar(this Element elemento, IBrowser browser, int tempo)
        {
            WaitForAjax(browser.ObterDriver(), 60, false);
            Thread.Sleep(tempo);
        }

        /// <summary>
        /// Espera o elemento aparecer na pagina
        /// </summary>
        /// <param name="elemento">Elemento esperado</param>
        /// <param name="browser">objeto do navegador</param>
        public static void EsperarElemento(this Element elemento, IBrowser browser)
        {
            WaitForAjax(browser.ObterDriver(), 100, false);
            var wait = new WebDriverWait(browser.ObterDriver(), TimeSpan.FromSeconds(SEGUNDOS_TIMEOUT_ELEMENTO));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(elemento.ObterBy()));
        }

		public static void EsperarIFrame(this Element elemento, IBrowser browser)
		{
			WaitForAjax(browser.ObterDriver(), 200, false);
			var wait = new WebDriverWait(browser.ObterDriver(), TimeSpan.FromSeconds(SEGUNDOS_TIMEOUT_ELEMENTO));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(elemento.ObterBy()));
        }

		public static void SairIFrame(this Element elemento, IBrowser browser)
		{
			browser.ObterDriver().SwitchTo().DefaultContent();
		}

		private static void WaitForAjax(this IWebDriver driver, int timeoutSecs = 60, bool throwException = false)
        {
            for (var i = 0; i < timeoutSecs; i++)
            {
                var javaScriptExecutor = driver as IJavaScriptExecutor;
                var ajaxIsComplete = javaScriptExecutor != null && (bool)javaScriptExecutor.ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete) return;
                Thread.Sleep(1000);
            }

            if (throwException)
                throw new TempoExpiradoException("O tempo limite da espera do AJAX foi completa");
        }

        public static string GetTexto(this Element elemento, IBrowser browser)
        {
            return browser.ObterDriver().FindElement(elemento.ObterBy()).Text;
        }

        public static string GetValorAtributo(this Element elemento, string atributo, IBrowser browser)
        {
            var iWebElement = BrowserHelpers.ObterIWebElement(browser, elemento);

            var valorAtributo =  browser.ObterDriver().FindElement(elemento.ObterBy()).GetAttribute(atributo);
            
            return valorAtributo;
        }

        public static string GetValorCss(this Element elemento, IBrowser browser)
        {
            var iWebElement = BrowserHelpers.ObterIWebElement(browser, elemento);

            string valorAtributo = browser.ObterDriver().FindElement(elemento.ObterBy()).GetAttribute("textContent");

            return valorAtributo;
        }

        public static string GetCssValue(this Element elemento, IBrowser browser, string value)
        {
            return browser.ObterDriver().FindElement(elemento.ObterBy()).GetCssValue(value);
        }

        public static string GetValue(this Element elemento, IBrowser browser)
        {
            return browser.ObterDriver().FindElement(elemento.ObterBy()).GetCssValue("val");
        }

        public static bool IsElementVisible(this Element elemento, IBrowser browser)
        {
            var iWebElement = BrowserHelpers.ObterIWebElement(browser, elemento);
            return iWebElement.Displayed && iWebElement.Enabled;
        }

        public static bool IsElementPresent(this Element elemento, IBrowser browser)
        {
            var wait = new WebDriverWait(browser.ObterDriver(), TimeSpan.FromSeconds(SEGUNDOS_TIMEOUT_ELEMENTO));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elemento.ObterBy()));
            var iWebElement = BrowserHelpers.ObterIWebElement(browser, elemento);
            return iWebElement.Displayed;
        }

        public static bool IsNotElementVisible(this Element elemento, IBrowser browser)
		{
			var wait = new WebDriverWait(browser.ObterDriver(), TimeSpan.FromSeconds(10));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(elemento.ObterBy()));
        }

		public static bool IsElementSelected(this Element elemento, IBrowser browser)
        {
            var iWebElement = BrowserHelpers.ObterIWebElement(browser, elemento);
            return iWebElement.Selected;
        }

		public static void WaitLoader(IBrowser browser)
		{
			var Loader = Element.Css("div[class='loader']");
			Loader.EsperarElemento(browser);
		}
	}
}