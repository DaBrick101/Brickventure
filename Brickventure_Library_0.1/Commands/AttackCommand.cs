using Brickventure_Library.Environment;

namespace Brickventure_Library_0._1.Commands
{
    public class AttackCommand : ICommand
    {
        private readonly IWorld _world;
        private string _key = "q";
        public AttackCommand(IWorld world)
        {
            _world = world;
        }
        public void Execute()//also Test
        {
            _world.GetPlayer().Attack();
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
