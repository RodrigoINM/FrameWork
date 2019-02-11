using Framework.Core.PageObjects;
using Framework.Core.Interfaces;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.FrameworkActions;

namespace FrameWorkGlobo.Pages
{
    public class ConsultaGooglePage : PageBase
    {
        private string GoogleUrl { get; }
        public Element InpPesquisar { get; private set; }
        public Element BtnPesquisaGoogle { get; private set; }

        public ConsultaGooglePage(IBrowser browser, string googleUrl) : base(browser)
        {
            GoogleUrl = googleUrl;

            InpPesquisar = Element.Css("input[title='Pesquisar']");
            BtnPesquisaGoogle = Element.Css("div[class='FPdoLc VlcLAe'] input[value='Pesquisa Google']");
        }

        public override void Navegar()
        {
            Browser.Abrir(GoogleUrl);
        }

        public void ConsultaGoogle(string Valor)
        {
            ElementExtensions.IsElementVisible(InpPesquisar, Browser);
            AutomatedActions.SendDataATM(Browser, InpPesquisar, Valor);
            KeyboardActions.Tab(Browser, InpPesquisar);

            ElementExtensions.IsElementVisible(BtnPesquisaGoogle, Browser);
            MouseActions.ClickATM(Browser, BtnPesquisaGoogle);
        }

        public void ValidarResultadoDaPesquisa(string Valor)
        {
            var textoDoLink = Element.Xpath("//h3[contains(., '" + Valor + "')]");
            ElementExtensions.IsElementVisible(textoDoLink, Browser);
        }
    }
}
