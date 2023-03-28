using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using Brickventure_Library_0._1;
using Brickventure_Library_0._1.Environment;

namespace BrickventureWebAPI.DTOs
{
    public class WorldDTO
    {
        private readonly IWorld _world;
        public string Message { get; set; }
        public int Health { get; set; }
        public IList<RoomDTO> GameField { get; set; }

        public WorldDTO(IWorld world, IOutputMessageWriter messageOutputWriter)
        {
            _world = world;
            Message = messageOutputWriter.GetMessage();
            Health = _world.GetPlayer().GetHealth();
            GameField = GetRoomDTOList();
        }
        private IList<RoomDTO> GetRoomDTOList()
        {
            List<RoomDTO> roomList = new List<RoomDTO>();

            var iroomList = _world.GetGameField();
            foreach (var iroom in iroomList)
            {
                RoomDTO room = new RoomDTO(iroom);
                roomList.Add(room);
            }

            return roomList;
        }
    }
}
