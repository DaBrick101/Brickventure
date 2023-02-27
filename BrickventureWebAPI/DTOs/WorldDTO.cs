using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using Brickventure_Library_0._1.Environment;

namespace BrickventureWebAPI.DTOs
{
    public class WorldDTO : IWorld
    {
        private readonly IWorld _world;

        public WorldDTO(IWorld world)
        {
            _world = world;
        }
        public IRoom GetCurrentRoom()
        {
            return _world.GetCurrentRoom();
        }

        public IRoom[,,] GetGameField()
        {
            var gameField = _world.GetGameField();
            return gameField;
        }

        public IPlayer GetPlayer()
        {
            throw new NotImplementedException();
        }

        public void SetPlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public IRoom GetRoomToMoveInto(Direction direction)
        {
            throw new NotImplementedException();
        }

        public void MovePlayer(Direction direction)
        {
            throw new NotImplementedException();
        }

        public int GetX()
        {
            throw new NotImplementedException();
        }

        public int GetY()
        {
            throw new NotImplementedException();
        }

        public int GetZ()
        {
            throw new NotImplementedException();
        }
    }
}
