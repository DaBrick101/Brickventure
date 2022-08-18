using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Timers;

[assembly: InternalsVisibleTo("BrickventureLibraryUnitTests")]
namespace Brickventure_Library_0._1.States
{

    public class PlayerStateTimer : IPlayerStateTimer
    {
        private readonly IPlayer _player;
        private readonly IWorld _world;
        public PlayerStateTimer(IPlayer player, IWorld world)
        {
            _player = player;
            _world = world;
        }

        //Check if i get stateX if StateY
        internal void PlayerStateChange(object sender, ElapsedEventArgs e)
        {
            if (_world.GetCurrentRoom().GetRoomType() == RoomType.EnemyRoom && _world.GetCurrentRoom().GetPartecipants().OfType<IEnemy>().Any())
            {
                if (_player.GetState() != null && !_player.GetState().WasSuccessfull())
                {
                    if (_player.GetHealth() == 0)
                    {
                        _player.SetState(new DeadPlayerState());
                    }
                    _player.SetState(new DefendPlayerState(_world));
                }
                else
                {
                    if (_player.GetState().GetType() == typeof(AttackPlayerState))
                    {
                        _player.SetState(new DefendPlayerState(_world));
                    }
                    else
                    {
                        _player.SetState(new AttackPlayerState(_world));
                    }
                }
            }
            else
            {
                _player.SetState(new IdlePlayerState());
            }
        }

        public void Start()
        {
            var timer = new Timer(1000);
            timer.Elapsed += PlayerStateChange;
            timer.Start();
        }
    }
}
