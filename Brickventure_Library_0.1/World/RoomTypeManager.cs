using System;

namespace Brickventure_Library.Environment
{
    public enum RoomType
    {
        EnemyRoom,
        //ShopRoom,
        //UpgradeRoom,
        HealRoom,
        SpawnRoom,
        BossRoom

    }


    public class RoomTypeManager
    {
        Random _ran = new Random();
        public bool ExcludeEnemyRoom { get; set; }
        public bool ExcludeShopRoom { get; set; }
        public bool ExcludeUpgradeRoom { get; set; }
        public bool ExcludeHealRoom { get; set; }
        public RoomType GetRandomRoomType()
        {
            var randomNumber = _ran.Next(0, 2);

            if (randomNumber == 0 && !ExcludeEnemyRoom)
            {
                return RoomType.EnemyRoom;
            }
            //else if (randomNumber == 1 && !ExcludeShopRoom)
            //{
            //    return RoomType.ShopRoom;
            //}
            //else if (randomNumber == 2 && ExcludeUpgradeRoom == false)
            //{
            //    return RoomType.UpgradeRoom;
            //}
            else if (randomNumber == 1 && ExcludeHealRoom == false)//Changed 3 to 1
            {
                return RoomType.HealRoom;
            }
            else
            {
                return RoomType.EnemyRoom;
            }



        }
    }
}
