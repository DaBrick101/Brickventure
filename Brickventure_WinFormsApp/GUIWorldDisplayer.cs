using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Brickventure_WinFormsApp
{
    public class GUIWorldDisplayer : IWorldDisplayer
    {
        private Dictionary<RoomType, string> _roomTypeMap = new Dictionary<RoomType, string>();
        private List<PictureBox> GUIRooms;
        private readonly IWorld _world;
        private readonly BrickventureForm _form;
        private readonly Dictionary<IRoom, PictureBox> _guiRoomMap = new Dictionary<IRoom, PictureBox>();

        public GUIWorldDisplayer(BrickventureForm form, IWorld world)
        {
            _form = form;
            _world = world;

            _guiRoomMap = _form.GetRoomMapping();
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
                        _guiRoomMap[_world.GetPlayer().GetCurrentRoom()].ImageLocation = @"C:\Users\lbhbur1\source\repos\Brickventure_Library_0.1\Brickventure_WinFormsApp\Images\Fighting-Final.png";
                    }
                    else if (gameField[0, y, x] == _world.GetCurrentRoom())
                    {
                        _guiRoomMap[_world.GetPlayer().GetCurrentRoom()].ImageLocation = @"C:\Users\lbhbur1\source\repos\Brickventure_Library_0.1\Brickventure_WinFormsApp\Images\Brick-Final.png";
                        //Get Picturebox where Player is?
                    }
                    else if (gameField[0, y, x].GetWasVisitedByPlayer())
                    {
                        //DisplayRoom(_roomTypeMap[currentRoomType]);//Display Room as Roomtype, have to do some check to know wich roomtype is wich IMG
                        if(gameField[0,y,x].GetRoomType() == RoomType.SpawnRoom)
                        {
                            _guiRoomMap[gameField[0, y, x]].ImageLocation = @"C:\Users\lbhbur1\source\repos\Brickventure_Library_0.1\Brickventure_WinFormsApp\Images\Spawn-Final.png";
                        }
                        else if(gameField[0, y, x].GetRoomType() == RoomType.EnemyRoom)
                        {
                            _guiRoomMap[gameField[0, y, x]].ImageLocation = @"C:\Users\lbhbur1\source\repos\Brickventure_Library_0.1\Brickventure_WinFormsApp\Images\Enemy-Final.png";
                        }
                        else if(gameField[0, y, x].GetRoomType() == RoomType.HealRoom)
                        {
                            _guiRoomMap[gameField[0, y, x]].ImageLocation = @"C:\Users\lbhbur1\source\repos\Brickventure_Library_0.1\Brickventure_WinFormsApp\Images\Heal-Final.png";
                        }
                    }
                }
            }
        }
        public void CreateRoomTypeMap()//TODO Rename
            // 180 days later, brick forgot and is never going to change the name xD
        {
            _roomTypeMap.Add(RoomType.SpawnRoom, @"C:\Users\lbhbur1\source\repos\Brickventure_Library_0.1\Brickventure_WinFormsApp\Images\Spawn-Final.png");
            _roomTypeMap.Add(RoomType.EnemyRoom, @"C:\Users\lbhbur1\source\repos\Brickventure_Library_0.1\Brickventure_WinFormsApp\Images\Enemy-Final.png");
            _roomTypeMap.Add(RoomType.HealRoom, @"C:\Users\lbhbur1\source\repos\Brickventure_Library_0.1\Brickventure_WinFormsApp\Images\Heal-Final.png");
            _roomTypeMap.Add(RoomType.BossRoom, "C:\\Users\\lbhbur1\\source\\repos\\Brickventure_Library_0.1\\Brickventure_WinFormsApp\\Images\\EnemyRoom.png");
        }
        public void SetRoomPicture(string picture)
        {
            //.ImageLocation = picture;//Set Stani IMG for Rooms something like ?
            //same here bruh
            //yarrak yarr
        }

        public void FillRoomList()
        {
            GUIRooms = _form.GetPictureBoxes();
        }
    }
}
