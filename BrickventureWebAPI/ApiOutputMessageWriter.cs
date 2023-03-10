using Brickventure_Library_0._1;

namespace BrickventureWebAPI
{
    public class ApiOutputMessageWriter : IOutputMessageWriter
    {
        public string Message { get; set; }
        public void Write(string message)
        {
            Message = message;
        }

        public void Clear()
        {
            Message = string.Empty;
        }

        public string GetMessage()
        {
            return Message;
        }
    }
}
