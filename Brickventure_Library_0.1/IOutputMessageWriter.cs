namespace Brickventure_Library_0._1
{
    public interface IOutputMessageWriter
    {
        void Write(string message);
        void Clear();
        string GetMessage();
    }
}
