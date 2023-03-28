using Brickventure_Library_0._1.States;

namespace Brickventure_Library.Partecipants
{
    public interface IPlayer : IPartecipant
    {
        void SetState(IPlayerState state);
        IPlayerState GetState();
        int GetHealth();
        void IncreaseHealth();
        void DecreaseHealth();
        void SetHealth(int health);

    }
}
