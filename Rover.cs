namespace MarsRoverApp
{
    public class Rover
    {
        public int Location { get; }
        public Cardinal CardinalDirection { get; }

        public DirectionTurn? Turn { get; }

        public Rover(int location, Cardinal direction, DirectionTurn turn)
        {
            Location = location;
            CardinalDirection = CardinalLookup.SetDirection(direction, turn) ?? Cardinal.South;
            Turn = turn;
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
