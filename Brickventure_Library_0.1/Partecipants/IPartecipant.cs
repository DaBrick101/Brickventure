using Brickventure_Library.Environment;

namespace Brickventure_Library.Partecipants
{
    public interface IPartecipant
    {


        public void Attack();
        public void Defend();
        public IRoom GetCurrentRoom();
        public void SetRoom(IRoom room);




    }
}
