namespace Brickventure_Library_0._1.Commands
{
    public class Invoker : IInvoker
    {

        ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }
        public void ExecuteCommand()
        {
            _command.Execute();

        }
        public void UndoCommand()
        {
            _command.Undo();
        }

    }
}
