namespace Brickventure_Library_0._1.Commands
{
    public interface ICommand
    {
        string GetKey();
        public void Execute();
        public void Undo();


    }
}
