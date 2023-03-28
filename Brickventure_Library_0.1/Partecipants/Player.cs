using System;
using System.Text.Json.Serialization;
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
            SetState(new IdlePlayerState());
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
                    _writer.Write("Attack!");
                }
                else if (_state is DefendPlayerState)
                {
                    Console.WriteLine("must defend");
                    _writer.Write("Defend!");
                }
                else if (_state is DeadPlayerState)
                {
                    _world.GetCurrentRoom().RemovePartecipant(this);
                    _writer.Write("GAME OVER!!!");
                }
                else if (_state is WonPlayerState)
                {
                    _writer.Write("YOU WON!!!");
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

        public void IncreaseHealth()
        {
            _health++;
        }

        public void DecreaseHealth()
        {
            _health--;
        }

        public void SetHealth(int health)
        {
            _health = health;
        }
    }
}
