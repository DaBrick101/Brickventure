namespace Brickventure_Library_0._1.Commands
{
    public interface IInvoker
    {
        public void SetCommand(ICommand command);
        public void ExecuteCommand();
        public void UndoCommand();


    }
}
