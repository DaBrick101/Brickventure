using Brickventure_Library.Environment;

namespace Brickventure_Library.Partecipants
{
    public abstract class Fighter : IPartecipant
    {

        public bool isAlive;
        public IRoom currentRoom;

        public IRoom GetCurrentRoom()
        {
            return currentRoom;
        }
        public void SetRoom(IRoom room)
        {
            currentRoom = room;
        }
        public virtual void Attack()
        {

        }
        public virtual void Defend()
        {

        }
    }
}
