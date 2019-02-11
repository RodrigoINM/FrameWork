using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Framework.Core.FrameworkActions
{
    public static class MouseActions
    {
        public static void MouseDragAndDropSML<T>(T browser, Element elementoBase, Element elementoAlvo) where T : IBrowser
        {
            Actions builder = new Actions(browser.ObterDriver());
            //elementoBase.IsClickable(browser);
            //builder
            //    .Click(browser.ObterDriver().FindElement(elementoBase.ObterBy()))
            //    .ClickAndHold(browser.ObterDriver().FindElement(elementoBase.ObterBy()))
            //    .MoveToElement(browser.ObterDriver().FindElement(elementoAlvo.ObterBy()))
            //    .DragAndDrop(browser.ObterDriver().FindElement(elementoBase.ObterBy()), browser.ObterDriver().FindElement(elementoAlvo.ObterBy()))
            //    .Build()
            //    .Perform();

            //OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(browser.ObterDriver());

            elementoBase.EsperarElemento(browser);
            elementoBase.IsClickable(browser);
            builder
                .Click(browser.ObterDriver().FindElement(elementoBase.ObterBy()))
                .ClickAndHold(browser.ObterDriver().FindElement(elementoBase.ObterBy()))
                .MoveToElement(browser.ObterDriver().FindElement(elementoAlvo.ObterBy()))
                .Build()
                .Perform();
            elementoBase.Esperar(browser, 1500);
            builder
                .Release(browser.ObterDriver().FindElement(elementoAlvo.ObterBy()))
                .Build()
                .Perform();
        }

        public static void ClickMouseMoveToElementSML<T>(T browser, Element elemento) where T : IBrowser
        {
            elemento.IsClickable(browser);
            Actions actions = new Actions(browser.ObterDriver());
            actions.MoveToElement(browser.ObterDriver().FindElement(elemento.ObterBy())).Click().Build().Perform();
        }

        public static void MouseMoveToElementSML<T>(T browser, Element elemento) where T : IBrowser
        {
            elemento.IsClickable(browser);
            Actions actions = new Actions(browser.ObterDriver());
            actions.MoveToElement(browser.ObterDriver().FindElement(elemento.ObterBy())).Build().Perform();
        }

        public static void SelectCheckBoxATM<T>(T browser, Element elemento) where T : IBrowser
        {
            var checkStatus = browser.ObterDriver().FindElement(elemento.ObterBy()).Selected;

            if (checkStatus) return;

            elemento.ClicarEsperarElemento(browser);
        }

        public static void SelectElementATM<T>(T browser, Element elemento, string texto) where T : IBrowser
        {
            var selectElement = new SelectElement(BrowserHelpers.ObterIWebElement(browser, elemento));
            selectElement.SelectByText(texto);
        }

        public static void SelectElementATMByValue<T>(T browser, Element elemento, string texto) where T : IBrowser
        {
            var selectElement = new SelectElement(BrowserHelpers.ObterIWebElement(browser, elemento));
            selectElement.SelectByValue(texto);
        }

        public static void ClickATM<T>(T browser, Element elemento) where T : IBrowser
        {
            elemento.IsClickable(browser);
            browser.ObterDriver().FindElement(elemento.ObterBy()).Click();
        }

        public static void DoubleClickATM<T>(T browser, Element elemento) where T : IBrowser
        {
            Actions builder = new Actions(browser.ObterDriver());
            elemento.IsClickable(browser);
            builder.DoubleClick(browser.ObterDriver().FindElement(elemento.ObterBy())).Build().Perform();
        }

        public static void ClickAndHoldATM<T>(T browser, Element elemento, Element elemento2) where T : IBrowser
        {
            Actions builder = new Actions(browser.ObterDriver());
            elemento.IsClickable(browser);
            builder
                .Click(browser.ObterDriver().FindElement(elemento.ObterBy()))
                .KeyDown(Keys.LeftControl)
                .Click(browser.ObterDriver().FindElement(elemento2.ObterBy()))
                .KeyUp(Keys.LeftControl)
                .Build()
                .Perform();
        }

        public static void HomeShiftDel<T>(T browser, Element elemento) where T : IBrowser
        {
            Actions builder = new Actions(browser.ObterDriver());
            elemento.IsClickable(browser);
            builder
                .Click(browser.ObterDriver().FindElement(elemento.ObterBy()))
                .KeyDown(Keys.LeftShift)
                .KeyDown(Keys.Home)
                .KeyUp(Keys.Home)
                .KeyUp(Keys.LeftControl)
                .Build()
                .Perform();
        }
    }
}
