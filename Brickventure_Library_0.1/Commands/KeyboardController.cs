using System;
using System.Collections.Generic;

namespace Brickventure_Library_0._1.Commands
{
    public class KeyboardController : IController
    {
        private readonly IInvoker _commandInvoker;
        private readonly IEnumerable<ICommand> _commands;
        public ICommand command;

        public KeyboardController(IInvoker commandInvoker, IEnumerable<ICommand> commands)
        {
            _commandInvoker = commandInvoker;
            _commands = commands;
        }

        public bool PerformCommand(string userInput) // the user input is the key in our map
        {
            command = GetCommand(userInput);
            if (command == null)
            {
                Console.WriteLine($"Command {userInput} was not found!");
                return false;
            }
            _commandInvoker.SetCommand(command);
            _commandInvoker.ExecuteCommand();

            return true;
        }

        public ICommand GetExecutedCommand()
        {
            return command;
        }

        private ICommand GetCommand(string key)
        {

            foreach (var command in _commands)
            {
                if (key == command.GetKey())
                {
                    return command;
                }

            }
            return null;

        }
    }
}
