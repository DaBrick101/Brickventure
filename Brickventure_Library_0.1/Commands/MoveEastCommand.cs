using Brickventure_Library.Environment;
using Brickventure_Library_0._1.Environment;

namespace Brickventure_Library_0._1.Commands
{
    public class MoveEastCommand : ICommand
    {
        private readonly IWorld _world;
        private string _key = "d";
        public MoveEastCommand(IWorld world)
        {
            _world = world;
        }
        public void Execute()
        {
            _world.MovePlayer(Direction.East);

        }

        public void Undo()
        {
            _world.MovePlayer(Direction.West);
        }

        public string GetKey()
        {
            return _key;
        }
    }
}
