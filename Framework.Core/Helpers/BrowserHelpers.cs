using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Framework.Core.Helpers
{
    public static class BrowserHelpers
    {
        public static void EliminarAlertasChrome(IBrowser browser)
        {
            var wait = new WebDriverWait(browser.ObterDriver(), TimeSpan.FromSeconds(10));

            if (wait == null)
            {
                EsperarJQueryAjax(browser);
            }

            try
            {
                IAlert alert = wait.Until(drv => {
                    try
                    {
                        return drv.SwitchTo().Alert();
                    }
                    catch (NoAlertPresentException)
                    {
                        return null;
                    }
                });
                alert.Accept();
            }
            catch (WebDriverTimeoutException) { /* Ignore */ }
        }

        public static IWebElement ObterIWebElement(IBrowser browser, Element elemento)
        {
            return browser.ObterDriver().FindElement(elemento.ObterBy());
        }

       public static IJavaScriptExecutor Scripts(this IBrowser browser)
        {
            return browser as IJavaScriptExecutor;
        }

        public static void EsperarJQueryAjax(IBrowser browser)
        {
            var jQueryStatus = (bool)(browser.Scripts().ExecuteScript("return (typeof(jQuery) != 'undefined')"));
            if (!jQueryStatus) return;

            while (true)
            {
                var ajaxCompleto = (bool)(browser.Scripts().ExecuteScript("return jQuery.active ==0"));
                if (ajaxCompleto) break;
                Thread.Sleep(100);
            }
        }
    }
}