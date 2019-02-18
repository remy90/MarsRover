namespace MarsRoverApp
{
    public static class CardinalLookup
    {
        public static Cardinal? SetDirection(Cardinal direction, DirectionTurn directionTurn)
        {
            if (direction == Cardinal.South)
                return directionTurn == DirectionTurn.Left ? Cardinal.East : Cardinal.West;
            else if (direction == Cardinal.West)
                return directionTurn == DirectionTurn.Left ? Cardinal.South : Cardinal.North;
            else if (direction == Cardinal.North)
                return directionTurn == DirectionTurn.Left ? Cardinal.West : Cardinal.East;
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
