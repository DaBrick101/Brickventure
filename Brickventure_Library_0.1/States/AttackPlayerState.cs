using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using System.Linq;

namespace Brickventure_Library_0._1.States
{
    public class AttackPlayerState : IPlayerState
    {
        private readonly IWorld _world;
        public AttackPlayerState(IWorld world)
        {
            _world = world;
        }
        public void Attack()
        {
            var enemyList = _world.GetCurrentRoom().GetPartecipants().OfType<IEnemy>();
            _world.GetCurrentRoom().RemovePartecipant((IPartecipant)enemyList.FirstOrDefault<IEnemy>());
        }

        public void Defend()
        {

        }

        public bool WasSuccessfull()
        {
            return true;
        }
    }
}
