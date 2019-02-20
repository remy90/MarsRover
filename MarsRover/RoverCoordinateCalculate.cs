using System;
using System.Collections.Generic;

namespace MarsRoverApp
{
    public class RoverCoordinateCalculate
    {
        /// <summary>
        /// Sets the Coordinates for the rover
        /// </summary>
        /// <returns></returns>
        /* Accept rover steps: x * 100 if % 100
         * 
         * If command is int, set number. If next number is int, add it to the previous, continue untill other command is received
         * If command is direction, change Cardinal and yProduct, increment/decrement xProduct accordingly
         * 
         */
        private readonly IEnumerable<string> commands;
        private readonly int _yScalar = 100;
        private readonly int _xScalar = 1;

        public RoverCoordinateCalculate(IEnumerable<string> commands)
        {
            this.commands = commands;
        }

        public (int, Cardinal) OrganiseSets()
        {
            int initialCoordinate = 1;
            var compass = Cardinal.South;
            int coordinate = initialCoordinate;
            foreach (var command in commands)
            {
                if (int.TryParse(command, out int meters))
                {
                    coordinate += SetCoordinateValue(compass, meters);
                    continue;
                }

                if (Enum.TryParse(command, out DirectionTurn direction))
                {
                    compass = CardinalLookup.SetDirection(compass, direction);

                }
            }

            return (coordinate, compass);
        }

        private int SetCoordinateValue(Cardinal cardinal, int coordinateChange)
        {
            switch (CardinalLookup.SetDirection(cardinal, DirectionTurn.None))
            {
                case Cardinal.South:
                    coordinateChange *= _yScalar; // Add 100 with every meter
                    break;
                case Cardinal.West:
                    coordinateChange = _xScalar; // subtract 1 with every meter
                    break;
                case Cardinal.North:
                    coordinateChange /= _yScalar; // Subtract 100 with every meter
                    break;
                case Cardinal.East:
                    coordinateChange = _xScalar; // Add 1 with every meter
                    break;
            }

            return coordinateChange; // return new coordinate
        }
    }
}
