using Brickventure_Library.Environment;

namespace Brickventure_Library_0._1.Commands
{
    public class DefendCommand : ICommand
    {
        private string _key = "e";
        private readonly IWorld _world;
        public DefendCommand(IWorld world)
        {
            _world = world;
        }
        public void Execute()
        {
            _world.GetPlayer().Defend();
        }

        public void Undo()
        {
        }

        public string GetKey()
        {
            return _key;
        }
    }
}
