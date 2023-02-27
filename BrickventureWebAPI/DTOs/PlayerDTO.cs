using Brickventure_Library.Environment;
using Brickventure_Library_0._1.States;
using Brickventure_Library_0._1;

namespace BrickventureWebAPI.DTOs
{
    public class PlayerDTO
    {
        public IPlayerState State;
        public IOutputMessageWriter Writer;
        public readonly IWorld World;
        public int Health = 3;
    }
}
