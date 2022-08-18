using Brickventure_Library.Environment;
using System;

namespace Brickventure_Library_0._1.Commands
{
    public class DisplayWorldCommand : ICommand
    {
        private readonly IWorld _world;
        private readonly IWorldDisplayer _worldDisplayer;

        public DisplayWorldCommand(IWorld world, IWorldDisplayer worldDisplayer)
        {
            _world = world;
            _worldDisplayer = worldDisplayer;
        }
        public void Execute()
        {
            _worldDisplayer.Display();
        }

        public string GetKey()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
