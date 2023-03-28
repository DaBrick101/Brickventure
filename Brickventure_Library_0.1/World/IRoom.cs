using Brickventure_Library.Partecipants;
using System.Collections.Generic;

namespace Brickventure_Library.Environment
{
    public interface IRoom
    {

        public int GetZ();
        public int GetY();
        public int GetX();
        public List<IPartecipant> GetPartecipants();

        public void AddPartecipants(List<IPartecipant> partecipants);

        public void AddPartecipant(IPartecipant partecipant);

        public void RemovePartecipant(IPartecipant partecipant);
        public void SetWasVisitedByPlayer();
        public bool GetWasVisitedByPlayer();
        public RoomType GetRoomType();
        void SetRoomType(RoomType roomtype);
        public void ChangeActivity(int isActive);
        public int GetActivity();
    }
}
