using Framework.Core.Interfaces;
using FrameWorkGlobo.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace FrameWorkGlobo.Steps
{
    [Binding]
    public sealed class ConsultaGoogleSteps
    {
        public ConsultaGooglePage TelaConsultaGooglePage { get; private set; }

        public ConsultaGoogleSteps()
        {
            var browser = ScenarioContext.Current["browser"];

            TelaConsultaGooglePage = new ConsultaGooglePage((IBrowser)browser,
                ConfigurationManager.AppSettings["GoogleUrl"]);
        }

        [Given(@"que estou na pagina do Google")]
        public void DadoQueEstouNaPaginaDoGoogle()
        {
            TelaConsultaGooglePage.Navegar();
        }

        [When(@"realizo uma pesquisa por SpecFlow")]
        public void QuandoRealizoUmaPesquisaPorSpecFlow()
        {
            TelaConsultaGooglePage.ConsultaGoogle("SpecFlow");
        }

        [Then(@"visualizo o site do SpecFlow no resultado da busca")]
        public void EntaoVisualizoOSiteDoSpecFlowNoResultadoDaBusca()
        {
            TelaConsultaGooglePage.ValidarResultadoDaPesquisa("SpecFlow - Binding Business Requirements to .NET Code");
        }

        [When(@"realizo uma pesquisa por SpecFlow ""(.*)""")]
        public void QuandoRealizoUmaPesquisaPorSpecFlow(string Busca)
        {
            TelaConsultaGooglePage.ConsultaGoogle(Busca);
        }

        [Then(@"visualizo o site do SpecFlow no resultado da busca ""(.*)""")]
        public void EntaoVisualizoOSiteDoSpecFlowNoResultadoDaBusca(string TextoDoLinkDoResultado)
        {
            TelaConsultaGooglePage.ValidarResultadoDaPesquisa(TextoDoLinkDoResultado);
        }


    }
}
