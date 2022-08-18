using Autofac;
using Brickventure_Library.Environment;
using Brickventure_Library_0._1;

namespace Brickventure_ConsoleApp
{
    public class ConsoleServiceFactory : ServiceFactory
    {
        private static ConsoleServiceFactory _instance;

        public static ConsoleServiceFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConsoleServiceFactory();
                }
                return _instance;
            }
        }

        private ConsoleServiceFactory()
        {
            ConfigureServices();
            _kernel = ConfigureServices();
        }

        private IContainer ConfigureServices()
        {
            var builder = GetConfiguredLibServices();
            builder.RegisterType<ConsoleWorldDisplayer>().As<IWorldDisplayer>();


            return builder.Build();
        }
    }
}
