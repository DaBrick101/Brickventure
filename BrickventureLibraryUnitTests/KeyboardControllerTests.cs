using Brickventure_Library.Environment;
using Brickventure_Library_0._1.Commands;
using Brickventure_Library_0._1.Partecipants;
using Brickventure_Library_0._1.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BrickventureLibraryUnitTests
{
    [TestClass]
    public class KeyboardControllerTests
    {

        //Invoker invoker;
        //World world;
        //MoveNorthCommand moveNorthCommand;
        //MoveEastCommand moveEastCommand;
        //MoveWestCommand moveWestCommand;
        //MoveSouthCommand moveSouthCommand;
        //AttackCommand attackCommand;
        //DefendCommand defendCommand;
        //KeyboardController keyboardController;

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    var invoke = new Invoker();
        //    var world = new World();
        //    var moveNorthCommand = new MoveNorthCommand(world);
        //    var moveEastCommand = new MoveEastCommand(world);
        //    var moveWestCommand = new MoveWestCommand(world);
        //    var moveSouthCommand = new MoveSouthCommand(world);
        //    var attackCommand = new AttackCommand(world);
        //    var defendCommand = new DefendCommand(world);
        //    var keyboardController = new KeyboardController(invoker,
        //        moveNorthCommand,
        //        moveEastCommand,
        //        moveSouthCommand,
        //        moveWestCommand,
        //        attackCommand,
        //        defendCommand);
        //}
        [TestMethod]
        public void PerformCommand_InvalidEntry_ReturnFalse()
        {
            //Arrange
            var invoker = new Invoker();
            var world = new World();
            var player = new Player(world, null);
            var moveNorthCommand = new MoveNorthCommand(world);
            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(moveNorthCommand);
            listCommands.AsEnumerable();
            var keyboardController = new KeyboardController(invoker, listCommands);

            //Act
            var result = keyboardController.PerformCommand("invalid entry");

            //Assert
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void PerformCommand_W_MoveNorthCommand()
        {
            //Arrange
            var invoker = new Invoker();
            var world = new World();
            var player = new Player(world, null);
            var moveNorthCommand = new MoveNorthCommand(world);
            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(moveNorthCommand);
            listCommands.AsEnumerable();
            var keyboardController = new KeyboardController(invoker, listCommands);

            //Act
            keyboardController.PerformCommand("w");

            //Assert
            //Assert.IsTrue(keyboardController.GetExecutedCommand().WasExecuted());
            Assert.AreEqual(moveNorthCommand.GetType(), keyboardController.GetExecutedCommand().GetType());
        }

        [TestMethod]
        public void PerformCommand_D_MoveEastCommand() //working, change all Tests like this test!
        {
            //Arrange
            var invoker = new Invoker();
            var world = new World();
            var player = new Player(world, null);
            var moveEastCommand = new MoveEastCommand(world);
            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(moveEastCommand);
            listCommands.AsEnumerable();
            var keyboardController = new KeyboardController(invoker, listCommands);

            //Act
            keyboardController.PerformCommand("d");

            //Assert
            //Assert.IsTrue(keyboardController.GetExecutedCommand().WasExecuted());
            Assert.AreEqual(typeof(MoveEastCommand), keyboardController.GetExecutedCommand().GetType());




        }

        [TestMethod]
        public void PerformCommand_S_MoveSouthCommand()
        {
            //Arrange
            var invoker = new Invoker();
            var world = new World();
            var player = new Player(world, null);
            var moveSouthCommand = new MoveSouthCommand(world);
            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(moveSouthCommand);
            listCommands.AsEnumerable();
            var keyboardController = new KeyboardController(invoker, listCommands);

            //Act
            keyboardController.PerformCommand("s");

            //Assert
            //Assert.IsTrue(keyboardController.GetExecutedCommand().WasExecuted());
            Assert.AreEqual(moveSouthCommand.GetType(), keyboardController.GetExecutedCommand().GetType());

        }

        [TestMethod]
        public void PerformCommand_A_MoveWestCommand()
        {
            //Arrange
            var invoker = new Invoker();
            var world = new World();
            var player = new Player(world, null);
            var moveWestCommand = new MoveWestCommand(world);
            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(moveWestCommand);
            listCommands.AsEnumerable();
            var keyboardController = new KeyboardController(invoker, listCommands);

            //Act
            keyboardController.PerformCommand("a");

            //Assert
            //Assert.IsTrue(keyboardController.GetExecutedCommand().WasExecuted());
            Assert.AreEqual(moveWestCommand.GetType(), keyboardController.GetExecutedCommand().GetType());
        }
        [TestMethod]
        public void PerformCommand_Q_AttackCommand()
        {
            //Arrange
            var invoker = new Invoker();
            var world = new World();
            var attackCommand = new AttackCommand(world);
            var player = new Player(world, null);
            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(attackCommand);
            listCommands.AsEnumerable();
            var keyboardController = new KeyboardController(invoker, listCommands);

            //Act
            player.SetState(new AttackPlayerState(world));
            keyboardController.PerformCommand("q");

            //Assert
            //Assert.IsTrue(keyboardController.GetExecutedCommand().WasExecuted());
            Assert.AreEqual(attackCommand.GetType(), keyboardController.GetExecutedCommand().GetType());
        }
        [TestMethod]
        public void PerformCommand_E_DefendCommand()
        {
            //Arrange
            var invoker = new Invoker();
            var world = new World();
            var defendCommand = new DefendCommand(world);
            var player = new Player(world, null);
            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(defendCommand);
            listCommands.AsEnumerable();
            var keyboardController = new KeyboardController(invoker, listCommands);

            //Act
            player.SetState(new DefendPlayerState(world));
            keyboardController.PerformCommand("e");

            //Assert
            //Assert.IsTrue(keyboardController.GetExecutedCommand().WasExecuted());
            Assert.AreEqual(defendCommand.GetType(), keyboardController.GetExecutedCommand().GetType());
        }
    }
}
