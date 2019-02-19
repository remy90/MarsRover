namespace MarsRoverApp
{
    public class Rover
    {
        public int Location { get; }
        public Cardinal CardinalDirection { get; }

        public Rover(int location, Cardinal direction, DirectionTurn turn)
        {
            Location = location;
            CardinalDirection = CardinalDirection;
        }
    }

    public enum Cardinal
    {
        South = 1,
        West,
        North,
        East
    }
}
