using System;
using Framework.Core.Exceptions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;

namespace Framework.Core.FrameworkActions
{
    public static class AutomatedActions
    {
        public static void TypingListATM<T>(T browser, Element primeiroElemento, Element segundoElemento, string texto) where T : IBrowser
        {
			primeiroElemento.EsperarElemento(browser);
			if (primeiroElemento.IsClickable(browser))
            {
                MouseActions.ClickATM(browser, primeiroElemento);
				segundoElemento.EsperarElemento(browser);
                browser.ObterDriver().FindElement(segundoElemento.ObterBy()).SendKeys(texto);
				segundoElemento.EsperarElemento(browser);
				KeyboardActions.Enter(browser, segundoElemento);
            }

            else
                throw new ElementoNaoEncontrado($"Houve um problema para acessar o elemento {primeiroElemento}.");
        }

        /// <summary>
        ///  Preenche um elemento do tipo input[type="text"] e executa um enter 
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="elemento"></param>
        /// <param name="dados"></param>
        public static void SendDataEnterATM<T>(T browser, Element elemento, string dados) where T : IBrowser
        {
            browser.ObterDriver().FindElement(elemento.ObterBy()).Clear();
            browser.ObterDriver().FindElement(elemento.ObterBy()).SendKeys(dados);
            browser.ObterDriver().FindElement(elemento.ObterBy()).SendKeys(OpenQA.Selenium.Keys.Enter);
        }
        /// <summary>
        /// Preenche um elemento do tipo input[type="text"]
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="elemento"></param>
        /// <param name="dados"></param>
        public static void SendDataATM<T>(T browser, Element elemento, string dados) where T : IBrowser
        {
            browser.ObterDriver().FindElement(elemento.ObterBy()).Clear();
            browser.ObterDriver().FindElement(elemento.ObterBy()).SendKeys(dados);
        }

        public static void SendData<T>(T browser, Element elemento, string dados) where T : IBrowser
        {
            browser.ObterDriver().FindElement(elemento.ObterBy()).SendKeys(dados);
        }
    }
}
