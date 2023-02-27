using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;

namespace BrickventureWebAPI.DTOs
{
    public class PartecipantDTO
    {
        public int PartecipantType { get; set; }

        public PartecipantDTO(IPartecipant partecipant)
        {
             Assign(partecipant);
        }

        public void Assign(IPartecipant partecipant)
        {
            if (partecipant is IPlayer)
            {
                PartecipantType = 1;
            }
            else if (partecipant is IEnemy)
            {
                PartecipantType = 2;
            }
        }
    }
}
