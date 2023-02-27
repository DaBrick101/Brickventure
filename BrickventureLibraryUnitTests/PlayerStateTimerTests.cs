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
    public class PlayerStateTimerTests
    {
        [TestMethod]
        public void PlayerChangeState_RoomTypeIsNotEnemyRoom_IdlePlayerState()
        {
            //Arrange
            var roomMock = new Mock<IRoom>();
            var worldMock = new Mock<IWorld>();
            var playerMock = new Mock<IPlayer>();

            worldMock.Setup(wm => wm.GetCurrentRoom()).Returns(roomMock.Object);

            var world = worldMock.Object;
            var player = playerMock.Object;
            var changeState = new PlayerStateTimer(player, world);

            //Act
            changeState.PlayerStateChange(null, null);

            //Assert
            playerMock.Verify(pm => pm.SetState(It.IsAny<IdlePlayerState>()), Times.Once); // make sure the player.SetState with a IdlePlayerState as parameter was called once.

        }
        [TestMethod]
        public void PlayerChangeState_RoomTypeIsEnemyRoomAndPreviousStateIdle_AttackPlayerState()
        {

            //Arrange
            var roomMock = new Mock<IRoom>();
            var worldMock = new Mock<IWorld>();
            var playerMock = new Mock<IPlayer>();
            var roomPartecipants = new List<IPartecipant> { new Enemy(), playerMock.Object };
            var changeState = new PlayerStateTimer(playerMock.Object, worldMock.Object);

            playerMock.Setup(pm => pm.GetState()).Returns(new IdlePlayerState());
            roomMock.Setup(rm => rm.GetRoomType()).Returns(RoomType.EnemyRoom);
            roomMock.Setup(rm => rm.GetPartecipants()).Returns(roomPartecipants);
            worldMock.Setup(wm => wm.GetCurrentRoom()).Returns(roomMock.Object);

            //Act
            changeState.PlayerStateChange(null, null);

            //Assert
            playerMock.Verify(pm => pm.SetState(It.IsAny<DefendPlayerState>()), Times.Never);
            playerMock.Verify(pm => pm.SetState(It.IsAny<IdlePlayerState>()), Times.Never);
            playerMock.Verify(pm => pm.SetState(It.IsAny<AttackPlayerState>()), Times.Once);
        }

        [TestMethod]
        public void PlayerChangeState_RoomTypeIsEnemyRoomPreviousStateAttackSuccsessfull_IdlePlayerState()
        {
            //Arrange
            var roomMock = new Mock<IRoom>();
            var worldMock = new Mock<IWorld>();
            var playerMock = new Mock<IPlayer>();
            var partecipants = new List<IPartecipant> { playerMock.Object };
            var changeState = new PlayerStateTimer(playerMock.Object, worldMock.Object);

            roomMock.Setup(rm => rm.GetRoomType()).Returns(RoomType.EnemyRoom);
            worldMock.Setup(wm => wm.GetCurrentRoom()).Returns(roomMock.Object);
            roomMock.Setup(rm => rm.GetPartecipants()).Returns(partecipants);
            playerMock.Setup(pm => pm.GetState()).Returns(new AttackPlayerState(worldMock.Object));

            //Act
            changeState.PlayerStateChange(null, null);

            //Assert
            playerMock.Verify(pm => pm.SetState(It.IsAny<IdlePlayerState>()), Times.Once);
        }
        [TestMethod]
        public void PlayerChangeState_RoomTypeIsEnemyRoomPreviousStateAttackUnsuccsessfull_DefendPlayerState()
        {
            //Arrange
            var roomMock = new Mock<IRoom>();
            var worldMock = new Mock<IWorld>();
            var playerMock = new Mock<IPlayer>();
            var partecipants = new List<IPartecipant> { playerMock.Object, new Enemy() };
            var changeState = new PlayerStateTimer(playerMock.Object, worldMock.Object);

            roomMock.Setup(rm => rm.GetRoomType()).Returns(RoomType.EnemyRoom);
            worldMock.Setup(wm => wm.GetCurrentRoom()).Returns(roomMock.Object);
            roomMock.Setup(rm => rm.GetPartecipants()).Returns(partecipants);
            playerMock.Setup(pm => pm.GetState()).Returns(new AttackPlayerState(worldMock.Object));

            //Act
            changeState.PlayerStateChange(null, null);

            //Assert
            playerMock.Verify(pm => pm.SetState(It.IsAny<DefendPlayerState>()), Times.Once);
        }

        [TestMethod]
        public void PlayerChangeState_RoomTypeIsEnemyRoomPreviousStateDefendSuccessfull_AttackPlayerState()
        {
            //Arrange
            var worldMock = new Mock<IWorld>();
            var roomMock = new Mock<IRoom>();
            var playerMock = new Mock<IPlayer>();
            var partecipants = new List<IPartecipant> { playerMock.Object, new Enemy() };
            var changeState = new PlayerStateTimer(playerMock.Object, worldMock.Object);

            roomMock.Setup(rm => rm.GetRoomType()).Returns(RoomType.EnemyRoom);
            worldMock.Setup(wm => wm.GetCurrentRoom()).Returns(roomMock.Object);
            roomMock.Setup(rm => rm.GetPartecipants()).Returns(partecipants);
            playerMock.Setup(pm => pm.GetState()).Returns(new DefendPlayerState(worldMock.Object));
            playerMock.Setup(pm => pm.GetState().WasSuccessfull()).Returns(true);

            //Act
            changeState.PlayerStateChange(null, null);

            //Assert
            playerMock.Verify(pm => pm.SetState(It.IsAny<AttackPlayerState>()), Times.Once);
        }

        [TestMethod]
        public void PlayerChangeState_RoomTypeIsEnemyRoomPreviousStateDefendUnsuccsessfull_DeadPlayerState()
        {
            //Arrange
            var worldMock = new Mock<IWorld>();
            var roomMock = new Mock<IRoom>();
            var playerMock = new Mock<IPlayer>();
            var partecipants = new List<IPartecipant> { playerMock.Object, new Enemy() };
            var changeState = new PlayerStateTimer(playerMock.Object, worldMock.Object);

            roomMock.Setup(rm => rm.GetRoomType()).Returns(RoomType.EnemyRoom);
            worldMock.Setup(wm => wm.GetCurrentRoom()).Returns(roomMock.Object);
            roomMock.Setup(rm => rm.GetPartecipants()).Returns(partecipants);
            playerMock.Setup(pm => pm.GetState()).Returns(new DefendPlayerState(worldMock.Object));

            //Act
            changeState.PlayerStateChange(null, null);

            //Assert
            playerMock.Verify(pm => pm.SetState(It.IsAny<DeadPlayerState>()), Times.Once);

        }
    }
}
