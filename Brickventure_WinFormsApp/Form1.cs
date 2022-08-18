using Brickventure_Library.Environment;
using Brickventure_Library_0._1.Commands;
using Brickventure_Library_0._1.States;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Brickventure_WinFormsApp
{
    public partial class BrickventureForm : Form
    {
        private List<PictureBox> _GUIRooms = new List<PictureBox>();
        private IWorld _world;
        private IController keyboardController;
        private ICommand displayWorld;
        private IPlayerStateTimer playerStateTimer;
        private Dictionary<IRoom, PictureBox> _guiRoomMap = new Dictionary<IRoom, PictureBox>();
        private IRoom[,,] _gameField;
        private int gameFieldMaxZ = 3;
        private int gameFieldMaxY = 5;
        private int gameFieldMaxX = 10;
        private string _key;

        public BrickventureForm(IWorld world)
        {
            InitializeComponent();
            _world = world;
        }
        private void BrickventureForm_Load(object sender, EventArgs e)
        {
            keyboardController = GUIServiceFactory.Instance.GetService<IController>();
            displayWorld = GUIServiceFactory.Instance.GetKeyedService<ICommand>("display");
            playerStateTimer = GUIServiceFactory.Instance.GetService<IPlayerStateTimer>();

            _gameField = _world.GetGameField();
        }

        public void SetPictureBoxes()
        {
            _GUIRooms.Add(Room_1);
            _GUIRooms.Add(Room_2);
            _GUIRooms.Add(Room_3);
            _GUIRooms.Add(Room_4);
            _GUIRooms.Add(Room_5);
            _GUIRooms.Add(Room_6);
            _GUIRooms.Add(Room_7);
            _GUIRooms.Add(Room_8);
            _GUIRooms.Add(Room_9);
            _GUIRooms.Add(Room_10);
            _GUIRooms.Add(Room_11);
            _GUIRooms.Add(Room_12);
            _GUIRooms.Add(Room_13);
            _GUIRooms.Add(Room_14);
            _GUIRooms.Add(Room_15);
            _GUIRooms.Add(Room_16);
            _GUIRooms.Add(Room_17);
            _GUIRooms.Add(Room_18);
            _GUIRooms.Add(Room_19);
            _GUIRooms.Add(Room_20);
            _GUIRooms.Add(Room_21);
            _GUIRooms.Add(Room_22);
            _GUIRooms.Add(Room_23);
            _GUIRooms.Add(Room_24);
            _GUIRooms.Add(Room_25);
            _GUIRooms.Add(Room_26);
            _GUIRooms.Add(Room_27);
            _GUIRooms.Add(Room_28);
            _GUIRooms.Add(Room_29);
            _GUIRooms.Add(Room_30);
            _GUIRooms.Add(Room_31);
            _GUIRooms.Add(Room_32);
            _GUIRooms.Add(Room_33);
            _GUIRooms.Add(Room_34);
            _GUIRooms.Add(Room_35);
            _GUIRooms.Add(Room_36);
            _GUIRooms.Add(Room_37);
            _GUIRooms.Add(Room_38);
            _GUIRooms.Add(Room_39);
            _GUIRooms.Add(Room_40);
            _GUIRooms.Add(Room_41);
            _GUIRooms.Add(Room_42);
            _GUIRooms.Add(Room_43);
            _GUIRooms.Add(Room_44);
            _GUIRooms.Add(Room_45);
            _GUIRooms.Add(Room_46);
            _GUIRooms.Add(Room_47);
            _GUIRooms.Add(Room_48);
            _GUIRooms.Add(Room_49);
            _GUIRooms.Add(Room_50);
        }
        public List<PictureBox> GetPictureBoxes()
        {
            return _GUIRooms;
        }

        public Dictionary<IRoom, PictureBox> GetRoomMapping()
        {
            return _guiRoomMap;
        }

        private void GUIRoomMapping()
        {
            var pictureBoxIndex = 0;

            for (int y = 0; y <= gameFieldMaxY - 1; y++)
            {
                for (int x = 0; x <= gameFieldMaxX - 1; x++)
                {
                    _guiRoomMap.Add(_gameField[0, y, x], _GUIRooms[pictureBoxIndex]);
                    pictureBoxIndex++;
                }
            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            SetPictureBoxes();
            GetPictureBoxes();
            GUIRoomMapping();

            playerStateTimer.Start();
            displayWorld.Execute();

        }

        private void BrickventureForm_KeyDown(object sender, KeyEventArgs e)
        {
            info_Textbox.Clear();
            
            _key = e.KeyCode.ToString().ToLower();
            keyboardController.PerformCommand(_key);
            displayWorld.Execute();
        }

        public TextBox GetTextBox()
        {
            return info_Textbox;
        }

        private void Attack_Button_Click(object sender, EventArgs e)
        {
            keyboardController.PerformCommand("q");
        }

        private void Defend_Button_Click(object sender, EventArgs e)
        {
            keyboardController.PerformCommand("e");
          
        }
    }
}
