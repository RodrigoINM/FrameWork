using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using OpenQA.Selenium;

namespace Framework.Core.FrameworkActions
{
    public static class KeyboardActions
    {
       
        /// <summary>
        /// Executa um Enter no teclado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="browser"></param>
        /// <param name="elemento"></param>
        public static void Enter<T>(T browser, Element elemento) where T : IBrowser
        {
           browser.ObterDriver().FindElement(elemento.ObterBy()).SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Simula um Tab(key) no elemento informado
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="elemento"></param>
        public static void Tab<T>(T browser, Element elemento) where T : IBrowser
        {
            browser.ObterDriver().FindElement(elemento.ObterBy()).SendKeys(Keys.Tab);
        }

        /// <summary>
        /// Simula um Escape no elemento informado
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="elemento"></param>
        public static void Escape<T>(T browser, Element elemento) where T : IBrowser
        {
            browser.ObterDriver().FindElement(elemento.ObterBy()).SendKeys(Keys.Escape);
        }

        /// <summary>
        /// Simula um backSpace no elemento informado
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="elemento"></param>
        public static void Backspace<T>(T browser, Element elemento) where T : IBrowser
        {
            browser.ObterDriver().FindElement(elemento.ObterBy()).SendKeys(Keys.Backspace);
        }

        /// <summary>
        /// Simula um Seta para Baixo no elemento informado
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="elemento"></param>
        public static void ArrowDonw<T>(T browser, Element elemento) where T : IBrowser
        {
            browser.ObterDriver().FindElement(elemento.ObterBy()).SendKeys(Keys.Down);
        }

        public static void ControlA<T>(T browser, Element elemento) where T : IBrowser
        {
            browser.ObterDriver().FindElement(elemento.ObterBy()).SendKeys(Keys.Control + "a");
        }

        public static void ShiftHome<T>(T browser, Element elemento) where T : IBrowser
        {
            browser.ObterDriver().FindElement(elemento.ObterBy()).SendKeys(Keys.LeftShift + Keys.Home);
        }
    }
}
