using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brickventure_ConsoleApp
{
    public class ConsoleWorldDisplayer : IWorldDisplayer
    {
        private Dictionary<RoomType, string> _roomTypeMap = new Dictionary<RoomType, string>();
        private readonly IWorld _world;

        public ConsoleWorldDisplayer(IWorld world)
        {
            CreateRoomTypeMap();
            _world = world;
        }

        public void Display()
        {

            IRoom[,,] gameField = _world.GetGameField();
            RoomType currentRoomType;

            try
            {
                Console.Clear();
            }
            catch
            {
                //ignore
            }

            for (int y = 0; y <= _world.GetY() - 1; y++)
            {
                Console.WriteLine("");
                for (int x = 0; x <= _world.GetX() - 1; x++)
                {
                    currentRoomType = gameField[0, y, x].GetRoomType();

                    if (gameField[0, y, x] == _world.GetCurrentRoom() && _world.GetCurrentRoom().GetPartecipants().OfType<IEnemy>().Any())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        DisplayRoom(_roomTypeMap[currentRoomType]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (gameField[0, y, x] == _world.GetCurrentRoom())
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("| O |");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (gameField[0, y, x].GetWasVisitedByPlayer() && _roomTypeMap.ContainsKey(currentRoomType))
                    {
                        DisplayRoom(_roomTypeMap[currentRoomType]);
                    }
                    else
                    {
                        Console.Write("| - |");
                    }
                }
            }
        }
        public void CreateRoomTypeMap()//TODO Rename
        {
            _roomTypeMap.Add(RoomType.SpawnRoom, "| X |");
            _roomTypeMap.Add(RoomType.EnemyRoom, "| E |");
            _roomTypeMap.Add(RoomType.HealRoom, "| H |");
            //_roomTypeMap.Add(RoomType.ShopRoom, "| $ |");
            //_roomTypeMap.Add(RoomType.UpgradeRoom, "| U |");
            _roomTypeMap.Add(RoomType.BossRoom, "| B |");
        }

        public void DisplayRoom(string symbol)
        {
            Console.Write(symbol);
        }


    }
}
