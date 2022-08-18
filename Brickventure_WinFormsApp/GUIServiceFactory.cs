using Autofac;
using Brickventure_Library.Environment;
using Brickventure_Library_0._1;

namespace Brickventure_WinFormsApp
{
    public class GUIServiceFactory : ServiceFactory
    {
        private static GUIServiceFactory _instance;

        public static GUIServiceFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GUIServiceFactory();
                }
                return _instance;
            }
        }

        private GUIServiceFactory()
        {
            ConfigureServices();
            _kernel = ConfigureServices();
        }

        private IContainer ConfigureServices()
        {
            var builder = GetConfiguredLibServices();
            builder.RegisterType<GUIWorldDisplayer>().As<IWorldDisplayer>();
            builder.RegisterType<BrickventureForm>().SingleInstance();
            builder.RegisterType<WriteMessageToGUI>().As<IOutputMessageWriter>();


            return builder.Build();
        }
    }
}

