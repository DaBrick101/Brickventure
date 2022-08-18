using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using Brickventure_Library_0._1.Partecipants;
using Brickventure_Library_0._1.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BrickventureLibraryUnitTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void SetState_InEnemyRoomDeadState_RemovePlayer()
        {
            //Arrange
            var worldMock = new Mock<IWorld>();
            var roomMock = new Mock<IRoom>();
            var player = new Player(worldMock.Object);
            var partecipants = new List<IPartecipant> { player };

            roomMock.Setup(rm => rm.GetRoomType()).Returns(RoomType.EnemyRoom);
            roomMock.Setup(rm => rm.GetPartecipants()).Returns(partecipants);
            worldMock.Setup(wm => wm.GetCurrentRoom()).Returns(roomMock.Object);

            //Act
            player.SetState(new DeadPlayerState());


            //Assert
            Assert.AreEqual(typeof(DeadPlayerState), player.GetState().GetType());
            worldMock.Verify(wm => wm.GetCurrentRoom().RemovePartecipant(player), Times.Once);


        }
        [TestMethod]
        public void SetState_InEnemyRoom_AttackState()
        {
            //Arrange
            var worldMock = new Mock<IWorld>();
            var roomMock = new Mock<IRoom>();
            var player = new Player(worldMock.Object);
            var partecipants = new List<IPartecipant> { player };

            roomMock.Setup(rm => rm.GetRoomType()).Returns(RoomType.EnemyRoom);
            roomMock.Setup(rm => rm.GetPartecipants()).Returns(partecipants);
            worldMock.Setup(wm => wm.GetCurrentRoom()).Returns(roomMock.Object);

            //Act
            player.SetState(new AttackPlayerState(worldMock.Object));

            //Assert
            Assert.AreEqual(typeof(AttackPlayerState), player.GetState().GetType());
        }
        [TestMethod]
        public void SetState_InEnemyRoom_DefendState()
        {
            //Arrange
            var worldMock = new Mock<IWorld>();
            var roomMock = new Mock<IRoom>();
            var player = new Player(worldMock.Object);
            var partecipants = new List<IPartecipant> { player };

            roomMock.Setup(rm => rm.GetRoomType()).Returns(RoomType.EnemyRoom);
            roomMock.Setup(rm => rm.GetPartecipants()).Returns(partecipants);
            worldMock.Setup(wm => wm.GetCurrentRoom()).Returns(roomMock.Object);

            //Act
            player.SetState(new DefendPlayerState(worldMock.Object));

            //Assert
            Assert.AreEqual(typeof(DefendPlayerState), player.GetState().GetType());
        }
        [TestMethod]
        public void SetState_NotInEnemyRoom_IdleState()
        {
            //Arrange
            var worldMock = new Mock<IWorld>();
            var roomMock = new Mock<IRoom>();
            var player = new Player(worldMock.Object);
            var partecipants = new List<IPartecipant> { player };

            roomMock.Setup(rm => rm.GetRoomType()).Returns(RoomType.EnemyRoom);
            roomMock.Setup(rm => rm.GetPartecipants()).Returns(partecipants);
            worldMock.Setup(wm => wm.GetCurrentRoom()).Returns(roomMock.Object);

            //Act
            player.SetState(new IdlePlayerState());

            //Assert
            Assert.AreEqual(typeof(IdlePlayerState), player.GetState().GetType());
        }

    }
}
