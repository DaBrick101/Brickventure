namespace Brickventure_Library_0._1.Environment
{
    public enum Direction
    {
        North,
        East,
        South,
        West,
        Empty
    }

    public static class DirectionParser
    {
        public static Direction StringToEnum(string direction)
        {
            Direction userDirection = Direction.Empty;


            if (direction == Direction.North.ToString().ToLower() || direction == "w")
            {
                userDirection = Direction.North;
            }
            else if (direction == Direction.East.ToString().ToLower() || direction == "d")
            {
                userDirection = Direction.East;
            }
            else if (direction == Direction.South.ToString().ToLower() || direction == "s")
            {
                userDirection = Direction.South;
            }
            else if (direction == Direction.West.ToString().ToLower() || direction == "a")
            {
                userDirection = Direction.West;
            }

            return userDirection;
        }
    }
}



