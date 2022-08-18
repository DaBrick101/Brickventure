using Brickventure_Library.Environment;
using Brickventure_Library_0._1.Environment;

namespace Brickventure_Library_0._1.Commands
{
    public class MoveNorthCommand : ICommand
    {
        private readonly IWorld _world;
        private string _key = "w";
        public MoveNorthCommand(IWorld world)
        {
            _world = world;
        }
        public void Execute()
        {
            _world.MovePlayer(Direction.North);
        }

        public void Undo()
        {
            _world.MovePlayer(Direction.South);
        }

        public string GetKey()
        {
            return _key;
        }
    }
}
