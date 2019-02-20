﻿namespace MarsRoverApp
{
    public class Rover
    {
        public int Location { get; }
        public Cardinal CardinalDirection { get; }

        public Rover(int location, Cardinal compass)
        {
            Location = location;
            CardinalDirection = compass;
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
