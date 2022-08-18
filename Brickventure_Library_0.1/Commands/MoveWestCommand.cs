using Brickventure_Library.Environment;
using Brickventure_Library_0._1.Environment;

namespace Brickventure_Library_0._1.Commands
{
    public class MoveWestCommand : ICommand
    {
        private readonly IWorld _world;
        private string _key = "a";
        public MoveWestCommand(IWorld world)
        {
            _world = world;
        }
        public void Execute()
        {
            _world.MovePlayer(Direction.West);
        }

        public string GetKey()
        {
            return _key;
        }

        public void Undo()
        {
            _world.MovePlayer(Direction.East);
        }
    }
}
