using Brickventure_Library_0._1.Commands;
using Brickventure_Library_0._1.States;
using System;

namespace Brickventure_ConsoleApp
{
    class Programs
    {
        static void Main(string[] args)
        {
            IController keyboardController = ConsoleServiceFactory.Instance.GetService<IController>();
            var displayWorld = ConsoleServiceFactory.Instance.GetKeyedService<ICommand>("display");
            var playerStateTimer = ConsoleServiceFactory.Instance.GetService<IPlayerStateTimer>();

            playerStateTimer.Start();
            bool stop = false;

            displayWorld.Execute();

            while (!stop)
            {
                Console.WriteLine("\n\n| W = Up   |\n| D = Left |\n| S = Down |\n| A = Right|\n| Q = Attack|\n| E = Defend|");

                var userInput = Console.ReadKey().KeyChar.ToString().ToLower();

                keyboardController.PerformCommand(userInput);
                displayWorld.Execute();
            }
        }
    }
}
