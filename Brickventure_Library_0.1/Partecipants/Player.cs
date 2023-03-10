using System;
using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using Brickventure_Library_0._1.States;


namespace Brickventure_Library_0._1.Partecipants
{
    public class Player : Fighter, IPlayer
    {
        IPlayerState _state;
        IOutputMessageWriter _writer;
        private readonly IWorld _world;
        private int _health = 3;
        public Player(IWorld world, IOutputMessageWriter writer)
        {
            _world = world;
            _world.SetPlayer(this);
            _writer = writer;
        }
        public override void Attack()
        {
            _state.Attack();
        }

        public override void Defend()
        {
            _state.Defend();
        }

        public void SetState(IPlayerState state)
        {
            _state = state;
            if (_world.GetCurrentRoom().GetRoomType() == RoomType.EnemyRoom)
            {
                if (_state is AttackPlayerState)
                {
                    Console.WriteLine("must attack");
                    _writer.Write("Quick you have to Attack!!!");
                }
                else if (_state is DefendPlayerState)
                {
                    Console.WriteLine("must defend");
                    _writer.Write("You missed!!! Quick you have to Defend");
                }
                else if (_state is DeadPlayerState)
                {
                    _health = _health - 1;
                    if(_health == 0)
                    {
                        _world.GetCurrentRoom().RemovePartecipant(this);
                        _writer.Write("GAME OVER!!!");
                    }
                    
                }

            }
        }
        public IPlayerState GetState()
        {
            return _state;
        }

        public int GetHealth()
        {
            return _health;
        }
    }
}
