using Brickventure_Library.Partecipants;
using Brickventure_Library_0._1.Environment;
using Brickventure_Library_0._1.Partecipants;
using Brickventure_Library_0._1.States;
using System.Linq;
using System.Numerics;

namespace Brickventure_Library.Environment
{
    public class World : IWorld
    {


        private IRoom[,,] _gameField;
        private IPlayer _player; //IPartecipant
        private IEnemy _enemy;


        private const int gameFieldMaxZ = 1;
        private const int gameFieldMaxY = 5;
        private const int gameFieldMaxX = 5;



        public World()
        {
            _gameField = new IRoom[gameFieldMaxZ, gameFieldMaxY, gameFieldMaxX];
            GenerateRooms();
        }

        private void GenerateRooms()
        {

            ClearGameField();
           
            RoomTypeManager roomTypeManager = new RoomTypeManager();

            for (int z = 0; z <= gameFieldMaxZ - 1; z++)
            {
                for (int y = 0; y <= gameFieldMaxY - 1; y++)
                {
                    for (int x = 0; x <= gameFieldMaxX - 1; x++)
                    {
                        if (_gameField[z, y, x] == null)
                        {

                            RoomType? northRoom;
                            RoomType? westRoom;


                            //collect 
                            if (x == 0)
                            {
                                westRoom = null;
                            }
                            else
                            {
                                westRoom = _gameField[z, y, x - 1].GetRoomType();
                            }

                            if (y == 0)
                            {
                                northRoom = null;
                            }
                            else
                            {
                                northRoom = _gameField[z, y - 1, x].GetRoomType();
                            }
                            if (westRoom == RoomType.HealRoom || northRoom == RoomType.HealRoom)
                            {
                                roomTypeManager.ExcludeHealRoom = true;
                            }



                            //create
                            _gameField[z, y, x] = new Room(roomTypeManager.GetRandomRoomType(), z, y, x);
                            if (_gameField[z, y, x].GetRoomType() == RoomType.EnemyRoom && _gameField[z,y,x] != _gameField[0,2,0])
                            {
                                _enemy = new Enemy();
                                _gameField[z, y, x].AddPartecipant(_enemy);
                            }

                            roomTypeManager.ExcludeShopRoom = false;
                            roomTypeManager.ExcludeUpgradeRoom = false;
                            roomTypeManager.ExcludeHealRoom = false;
                        }

                    }
                }
            }
            
        }

        public void MovePlayer(Direction direction)
        {
            _player.SetState(new IdlePlayerState());
            IRoom nextRoom = GetRoomToMoveInto(direction);
            IRoom currentRoom = _player.GetCurrentRoom();
            currentRoom.SetWasVisitedByPlayer();
            currentRoom.RemovePartecipant(_player);
            nextRoom.AddPartecipant(_player);
        }

        public IRoom GetRoomToMoveInto(Direction direction)
        {
            IRoom currentRoom = _player.GetCurrentRoom();
            if (direction == Direction.North)
            {
                if (currentRoom.GetY() == 0)
                {
                    return currentRoom;
                }
                else
                {
                    return _gameField[currentRoom.GetZ(), currentRoom.GetY() - 1, currentRoom.GetX()];
                }

            }
            else if (direction == Direction.East)
            {

                if (currentRoom.GetX() == GetX() - 1)
                {
                    return _gameField[currentRoom.GetZ(), currentRoom.GetY(), currentRoom.GetX()];
                }
                else
                {
                    return _gameField[currentRoom.GetZ(), currentRoom.GetY(), currentRoom.GetX() + 1];
                }
            }
            else if (direction == Direction.South)
            {
                if (currentRoom.GetY() == GetY() - 1)
                {
                    return _gameField[currentRoom.GetZ(), currentRoom.GetY(), currentRoom.GetX()];
                }
                else
                {
                    return _gameField[currentRoom.GetZ(), currentRoom.GetY() + 1, currentRoom.GetX()];

                }
            }
            else if (direction == Direction.West)
            {
                if (currentRoom.GetX() == 0)
                {
                    return _gameField[currentRoom.GetZ(), currentRoom.GetY(), currentRoom.GetX()];
                }
                else
                {
                    return _gameField[currentRoom.GetZ(), currentRoom.GetY(), currentRoom.GetX() - 1];
                }
            }

            return null;
        }

        public IRoom[,,] GetGameField()
        {
            return _gameField;
        }

        public IPlayer GetPlayer()
        {
            return _player;
        }

        public IRoom GetCurrentRoom()
        {
            return _player.GetCurrentRoom();
        }


        public void SetPlayer(IPlayer player)
        {
            _player = player;
            _player.SetRoom(_gameField[0, 2, 0]);
            _gameField[0, 2, 0].AddPartecipant(_player);
        }

        public int GetX()
        {
            return gameFieldMaxX;
        }

        public int GetY()
        {
            return gameFieldMaxY;
        }

        public int GetZ()
        {
            return gameFieldMaxZ;
        }

        public bool DidPlayerWin()
        {
            for (int z = 0; z <= gameFieldMaxZ - 1; z++)
            {
                for (int y = 0; y <= gameFieldMaxY - 1; y++)
                {
                    for (int x = 0; x <= gameFieldMaxX - 1; x++)
                    {
                        if (_gameField[z, y, x].GetPartecipants().OfType<IEnemy>().Any())
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void Restart()
        {
            GenerateRooms();

            _gameField[0, 2, 0].SetRoomType(RoomType.SpawnRoom);
            _player.SetRoom(_gameField[0, 2, 0]);
            _gameField[0, 2, 0].AddPartecipant(_player);
        }

        private void ClearGameField()
        {

            for (int z = 0; z <= gameFieldMaxZ - 1; z++)
            {
                for (int y = 0; y <= gameFieldMaxY - 1; y++)
                {
                    for (int x = 0; x <= gameFieldMaxX - 1; x++)
                    {
                        _gameField[z, y, x] = null;
                    }
                }
            }
        }
    }
}
