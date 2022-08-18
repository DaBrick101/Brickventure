using Brickventure_Library.Environment;
using Brickventure_Library_0._1.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BrickventureLibraryUnitTests
{
    [TestClass]
    public class CommandTests
    {

        [TestMethod]
        public void AttackCommand_WhenCalled_PlayerAttacked()
        {
            //Arrange
            var invokerMock = new Mock<IInvoker>();
            var worldMock = new Mock<IWorld>();

            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(new AttackCommand(worldMock.Object));
            listCommands.AsEnumerable();

            var keyboardController = new KeyboardController(invokerMock.Object, listCommands);


            //Act
            var result = keyboardController.PerformCommand("q");


            //Assert
            Assert.IsTrue(result);
            invokerMock.Verify(im => im.SetCommand(It.IsAny<AttackCommand>()), Times.Once);
            invokerMock.Verify(im => im.ExecuteCommand(), Times.Once);

        }

        [TestMethod]
        public void DefendCommand_WhenCalled_PlayerDefended()
        {
            //Arrange
            var invokerMock = new Mock<IInvoker>();
            var worldMock = new Mock<IWorld>();

            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(new DefendCommand(worldMock.Object));
            listCommands.AsEnumerable();

            var keyboardController = new KeyboardController(invokerMock.Object, listCommands);


            //Act
            var result = keyboardController.PerformCommand("e");


            //Assert
            Assert.IsTrue(result);
            invokerMock.Verify(im => im.SetCommand(It.IsAny<DefendCommand>()), Times.Once);
            invokerMock.Verify(im => im.ExecuteCommand(), Times.Once);

        }

        [TestMethod]
        public void MoveNorthCommand_WhenCalled_PlayerMovedNorth()
        {
            //Arrange
            var invokerMock = new Mock<IInvoker>();
            var worldMock = new Mock<IWorld>();
            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(new MoveNorthCommand(worldMock.Object));
            listCommands.AsEnumerable();
            var keyboardController = new KeyboardController(invokerMock.Object, listCommands);

            //Act
            keyboardController.PerformCommand("w");

            //Assert
            invokerMock.Verify(im => im.SetCommand(It.IsAny<MoveNorthCommand>()), Times.Once);
            invokerMock.Verify(im => im.ExecuteCommand(), Times.Once);

        }
        [TestMethod]
        public void MoveEastCommand_WhenCalled_PlayerMovedEast()
        {
            //Arrange
            var invokerMock = new Mock<IInvoker>();
            var worldMock = new Mock<IWorld>();
            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(new MoveEastCommand(worldMock.Object));
            listCommands.AsEnumerable();
            var keyboardController = new KeyboardController(invokerMock.Object, listCommands);

            //Act
            keyboardController.PerformCommand("d");

            //Assert
            invokerMock.Verify(im => im.SetCommand(It.IsAny<MoveEastCommand>()), Times.Once);
            invokerMock.Verify(im => im.ExecuteCommand(), Times.Once);

        }
        [TestMethod]
        public void MoveSouthCommand_WhenCalled_PlayerMovedSouth()
        {
            //Arrange
            var invokerMock = new Mock<IInvoker>();
            var worldMock = new Mock<IWorld>();
            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(new MoveSouthCommand(worldMock.Object));
            listCommands.AsEnumerable();
            var keyboardController = new KeyboardController(invokerMock.Object, listCommands);

            //Act
            keyboardController.PerformCommand("s");

            //Assert
            invokerMock.Verify(im => im.SetCommand(It.IsAny<MoveSouthCommand>()), Times.Once);
            invokerMock.Verify(im => im.ExecuteCommand(), Times.Once);


        }
        [TestMethod]
        public void MoveWestCommand_WhenCalled_ReturnPlayerMovedWestTrue()
        {
            //Arrange
            var invokerMock = new Mock<IInvoker>();
            var worldMock = new Mock<IWorld>();
            List<ICommand> listCommands = new List<ICommand>();
            listCommands.Add(new MoveWestCommand(worldMock.Object));
            listCommands.AsEnumerable();
            var keyboardController = new KeyboardController(invokerMock.Object, listCommands);

            //Act
            keyboardController.PerformCommand("a");

            //Assert
            invokerMock.Verify(im => im.SetCommand(It.IsAny<MoveWestCommand>()), Times.Once);
            invokerMock.Verify(im => im.ExecuteCommand(), Times.Once);


        }
    }
}
