using Brickventure_Library.Partecipants;
using Brickventure_Library_0._1.Environment;

namespace Brickventure_Library.Environment
{
    public interface IWorld
    {
        IRoom GetCurrentRoom();
        IRoom[,,] GetGameField();
        IPlayer GetPlayer();
        void SetPlayer(IPlayer player);
        IRoom GetRoomToMoveInto(Direction direction);
        void MovePlayer(Direction direction);
        int GetX();
        int GetY();
        int GetZ();
    }
}