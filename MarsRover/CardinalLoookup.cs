namespace MarsRoverApp
{
    public static class CardinalLookup
    {
        public static Cardinal SetDirection(Cardinal direction, DirectionTurn directionTurn)
        {
            if (directionTurn == DirectionTurn.None)
                return direction;
            if (direction == Cardinal.South)
                return directionTurn == DirectionTurn.Left ? Cardinal.East : Cardinal.West;
            else if (direction == Cardinal.West)
                return directionTurn == DirectionTurn.Left ? Cardinal.South : Cardinal.North;
            else if (direction == Cardinal.North)
                return directionTurn == DirectionTurn.Left ? Cardinal.West : Cardinal.East;
            else if (direction == Cardinal.East)
                return directionTurn == DirectionTurn.Left ? Cardinal.North : Cardinal.South;
            return direction;
        }
    }

    public enum DirectionTurn
    {
        Left,
        Right,
        None
    }
}
