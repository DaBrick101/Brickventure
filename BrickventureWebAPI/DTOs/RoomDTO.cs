using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using Brickventure_Library_0._1.Environment;

namespace BrickventureWebAPI.DTOs
{
    public class RoomDTO
    {
        public RoomType RoomType { get; set; }
        public List<PartecipantDTO> Partecipants { get; set; }
        public bool WasVisitedByPlayer { get; set; }
        public int IsActive { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public RoomDTO(IRoom room)
        {
            Assign(room);
        }
        public void Assign(IRoom room)
        {
            if (room == null) return;
            AssignPartecipants(room);
            RoomType = room.GetRoomType();
            WasVisitedByPlayer = room.GetWasVisitedByPlayer();
            IsActive = room.GetActivity();
            X = room.GetX();
            Y = room.GetY();
            Z = room.GetZ();
        }
        public void AssignPartecipants(IRoom room)
        {
            if (room == null) return;

            var iPartecipants = room.GetPartecipants();
            if (iPartecipants != null)
            {
                Partecipants = new List<PartecipantDTO>();
                foreach (var partecipant in iPartecipants)
                {
                    if (partecipant != null)
                    {
                        PartecipantDTO partecipantDTO = new PartecipantDTO(partecipant);
                        Partecipants.Add(partecipantDTO);
                    }

                }
            }
        }
    }
}
