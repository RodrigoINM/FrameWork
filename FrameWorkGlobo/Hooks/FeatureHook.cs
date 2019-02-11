using Framework.Core.Interfaces;
using Framework.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FrameWorkGlobo.Hooks
{
    [Binding]
    public class FeatureHook
    {
        private static IBrowser Browser;

        public FeatureHook()
        {
            var browser = ScenarioContext.Current["browser"];
        }

        [BeforeScenario]
        public static void Before()
        {
            Browser = BrowserBuilder.ObterBrowser(
                         ScenarioContext.Current.ScenarioInfo.Tags.FirstOrDefault(f => f == "chrome" || f == "firefox" || f == "ie"));

            Thread.Sleep(1000);
            Browser.Iniciar();

            ScenarioContext.Current.Add("browser", Browser);
        }

        public static void FinalizarDriver()
        {
            Browser.Finalizar();
        }

        public static void FecharDriver()
        {
            Browser.Fechar();
        }

        [AfterScenario]
        public void ExcluirMassas()
        {
            FecharDriver();
        }

        [AfterFeature("kill_Driver")]
        public static void MatarDriver()
        {
            Browser.KillDriver();
        }
    }
}
