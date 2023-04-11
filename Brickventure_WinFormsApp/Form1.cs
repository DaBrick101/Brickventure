using Brickventure_Library.Environment;
using Brickventure_Library_0._1.Commands;
using Brickventure_Library_0._1.States;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Brickventure_WinFormsApp
{
    public partial class BrickventureForm : Form
    {
        private List<PictureBox> _GUIRooms = new List<PictureBox>();
        private IWorld _world;
        private IController _keyboardController;
        private ICommand displayWorld;
        private IPlayerStateTimer playerStateTimer;
        private Dictionary<IRoom, PictureBox> _guiRoomMap = new Dictionary<IRoom, PictureBox>();
        private IRoom[,,] _gameField;
        private int gameFieldMaxZ = 1;
        private int gameFieldMaxY = 5;
        private int gameFieldMaxX = 5;
        private string _key;

        public BrickventureForm(IWorld world)
        {
            InitializeComponent();
            _world = world;
        }
        private void BrickventureForm_Load(object sender, EventArgs e)
        {
            _keyboardController = GUIServiceFactory.Instance.GetService<IController>();
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
            _GUIRooms.Add(Room_11);
            _GUIRooms.Add(Room_12);
            _GUIRooms.Add(Room_13);
            _GUIRooms.Add(Room_14);
            _GUIRooms.Add(Room_15);
            _GUIRooms.Add(Room_21);
            _GUIRooms.Add(Room_22);
            _GUIRooms.Add(Room_23);
            _GUIRooms.Add(Room_24);
            _GUIRooms.Add(Room_25);
            _GUIRooms.Add(Room_31);
            _GUIRooms.Add(Room_32);
            _GUIRooms.Add(Room_33);
            _GUIRooms.Add(Room_34);
            _GUIRooms.Add(Room_35);
            _GUIRooms.Add(Room_41);
            _GUIRooms.Add(Room_42);
            _GUIRooms.Add(Room_43);
            _GUIRooms.Add(Room_44);
            _GUIRooms.Add(Room_45);
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
            _keyboardController.PerformCommand(_key);
            displayWorld.Execute();
        }

        public TextBox GetTextBox()
        {
            return info_Textbox;
        }

        private void Attack_Button_Click(object sender, EventArgs e)
        {
            _keyboardController.PerformCommand("q");
            displayWorld.Execute();
        }

        private void Defend_Button_Click(object sender, EventArgs e)
        {
            _keyboardController.PerformCommand("e");
            displayWorld.Execute();
        }
    }
}
