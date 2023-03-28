using System;
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
        private bool _isRunning;
        private int _interval;
        
        
        public PlayerStateTimer(IPlayer player, IWorld world)
        {
            _player = player;
            _world = world;
            _interval = 3000;
        }

        //Check if i get stateX if StateY
        internal void PlayerStateChange(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine($"elapsed {DateTime.Now.ToLongTimeString()}");
            if (_player.GetState() != null && _player.GetState().GetType() == typeof(DeadPlayerState))
            {
                return;
            }

            if (_world.DidPlayerWin())
            {
                _player.SetState(new WonPlayerState());
                return;
            }

            if (_world.GetCurrentRoom().GetRoomType() == RoomType.HealRoom &&
                _world.GetCurrentRoom().GetPartecipants().OfType<IPlayer>().Any())
            {
                if (_world.GetCurrentRoom().GetActivity() == 1)
                {
                    _player.IncreaseHealth();
                    _world.GetCurrentRoom().ChangeActivity(0);
                    return;
                }

                return;

            }

            // if (_player.GetState().GetType() == typeof(AttackPlayerState))
            // {
            //     if (_player.GetState().WasSuccessfull())
            //     {
            //         IncreaseDifficulty(250);
            //         Console.WriteLine("Interval:" + _interval);
            //     }
            //
            // }
            if (_world.GetCurrentRoom().GetRoomType() == RoomType.EnemyRoom && _world.GetCurrentRoom().GetPartecipants().OfType<IEnemy>().Any())
            {
                if (_player.GetState() != null && !_player.GetState().WasSuccessfull())
                {
                    if (_player.GetHealth() <= 0)
                    {
                        Console.WriteLine($"State  dead");
                        _player.SetState(new DeadPlayerState());
                    }
                    else
                    {
                        _player.SetState(new DefendPlayerState(_world));
                    }
                }
                else
                {
                    //Random State Attack||Defend
                    SetRandomState();

                    //Attack -> Defend Logic
                    //if (_player.GetState().GetType() == typeof(AttackPlayerState))
                    //{
                    //    Console.WriteLine($"State  defend");
                    //    _player.SetState(new DefendPlayerState(_world));
                    //}
                    //else
                    //{
                    //    Console.WriteLine($"State  attack");
                    //    SetRandomState();

                    //}
                }
            }
            else
            {
                _player.SetState(new IdlePlayerState());
            }
        }

        public void Start()
        {
            if (_isRunning)
            {
                return;
            }
            var timer = new Timer(_interval);
            timer.Elapsed += PlayerStateChange;
            timer.Start();
            _isRunning = true;
        }

        public void SetRandomState()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 3);

            if (num == 1)
            {
                _player.SetState(new AttackPlayerState(_world));
            }
            else
            {
                _player.SetState(new DefendPlayerState(_world));
            }
        }

        public void IncreaseDifficulty(int amount)
        {
            _interval -= amount;
        }
    }
}
