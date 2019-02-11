using SimpleInjector;
using SimpleInjector.Lifestyles;
using Framework.Core.Browsers;
using Framework.Core.Interfaces;

namespace Framework.IoC
{
    class IoC
    {
        private static Container _container;

        private static Container Container
        {
            get
            {
                if ((_container == null)) _container = SetTestUnitContainer();
                return _container;
            }
        }

        public static T GetInstance<T>() where T : class
        {
            return Container.GetInstance<T>();
        }

        private static Container SetTestUnitContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            container.Register(() => new ChromeBrowser(), Lifestyle.Scoped);
            container.Register(() => new FireFoxBrowser(), Lifestyle.Scoped);
            container.Register(() => new InternetExplorerBrowser(), Lifestyle.Scoped);

#pragma warning disable CS0618 // Type or member is obsolete
            container.RegisterCollection<IBrowser>(new[] {typeof(ChromeBrowser),
                typeof(FireFoxBrowser),
                typeof(InternetExplorerBrowser)
            });
#pragma warning restore CS0618 // Type or member is obsolete

#pragma warning disable CS0618 // Type or member is obsolete
            container.RegisterSingleton<IBrowserFactory>(new BrowserFactory {
                { "chrome", () => container.GetInstance<ChromeBrowser>() },
                { "firefox", () => container.GetInstance<FireFoxBrowser>() },
                { "ie", () => container.GetInstance<InternetExplorerBrowser>() }
            });
#pragma warning restore CS0618 // Type or member is obsolete

            container.Verify();

            return container;
        }

        public static void BeginLifeTimeScope()
        {
            ThreadScopedLifestyle.BeginScope(Container);
        }
    }
}
