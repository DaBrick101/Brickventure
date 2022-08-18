using Autofac;
using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using Brickventure_Library_0._1.Commands;
using Brickventure_Library_0._1.Partecipants;
using Brickventure_Library_0._1.States;
using System.Collections.Generic;

namespace Brickventure_Library_0._1
{
    public abstract class ServiceFactory
    {

        protected IContainer _kernel;


        protected ContainerBuilder GetConfiguredLibServices()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<KeyboardController>().As<IController>();
            builder.RegisterType<World>().As<IWorld>().SingleInstance();
            builder.RegisterType<Player>().As<IPlayer>().SingleInstance();
            builder.RegisterType<MoveNorthCommand>().As<ICommand>();
            builder.RegisterType<MoveEastCommand>().As<ICommand>();
            builder.RegisterType<MoveSouthCommand>().As<ICommand>();
            builder.RegisterType<MoveWestCommand>().As<ICommand>();
            builder.RegisterType<AttackCommand>().As<ICommand>();
            builder.RegisterType<DefendCommand>().As<ICommand>();
            builder.RegisterType<DisplayWorldCommand>().Keyed<ICommand>("display");
            builder.RegisterType<Invoker>().As<IInvoker>();
            builder.RegisterType<PlayerStateTimer>().As<IPlayerStateTimer>();
            


            return builder;
        }

        public T GetService<T>()
        {
            using (var scope = _kernel.BeginLifetimeScope())
            {
                return scope.Resolve<T>();
            }
        }
        public IEnumerable<T> GetServices<T>()
        {
            using (var scope = _kernel.BeginLifetimeScope())
            {
                return scope.Resolve<IEnumerable<T>>();
            }
        }
        public T GetKeyedService<T>(object key)
        {
            using (var scope = _kernel.BeginLifetimeScope())
            {
                return scope.ResolveKeyed<T>(key);
            }
        }
    }
}
