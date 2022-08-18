using Brickventure_Library.Environment;
using System;
using System.Collections.Generic;

namespace Brickventure_Library_0._1.Commands
{
    class DisplayWorldToGUICommand : ICommand
    {
        private Dictionary<RoomType, string> _roomTypeMap = new Dictionary<RoomType, string>();
        private readonly IWorld _world;

        public DisplayWorldToGUICommand(IWorld world)
        {
            CreateRoomTypeMap();
            _world = world;
        }

        public void CreateRoomTypeMap()
        {

        }

        public void Execute()
        {

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
