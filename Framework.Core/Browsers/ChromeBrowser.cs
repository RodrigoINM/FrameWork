using OpenQA.Selenium.Chrome;

namespace Framework.Core.Browsers
{
    public class ChromeBrowser : BrowserBase
    {
        public override void Iniciar()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("password_manager_enabled", false);
            options.AddArguments("--test-type", "--start-maximized");
            options.AddArguments("--test-type", "--ignore-certificate-errors");
            options.AddArgument("--disable-notifications");
            options.AddArgument("no-sandbox");
            options.AddArgument("--proxy-auto-detect");
            //options.AddArgument("--headless");
            SetupDriver(new ChromeDriver(options));
        }
    }
}