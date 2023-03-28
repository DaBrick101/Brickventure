using Brickventure_Library.Environment;

namespace Brickventure_Library_0._1.States
{
    public class DefendPlayerState : IPlayerState
    {
        bool wasDefended = false;
        private readonly IWorld _world;
        public DefendPlayerState(IWorld world)
        {
            _world = world;
            if (_world.GetCurrentRoom().GetRoomType() != RoomType.EnemyRoom)
            {
                wasDefended = true;

            }
        }
        public void Attack()
        {
        }

        public void Defend()
        {
            wasDefended = true;
        }

        public bool WasSuccessfull()
        {
            if (!wasDefended)
            {
                _world.GetPlayer().DecreaseHealth();
            }
            return wasDefended;
        }
    }
}
