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

        public RoverCoordinateCalculate(IEnumerable<string> commands)
        {
            this.commands = commands;
        }

        public (int Location, Cardinal Compass) OrganiseSets()
        {
            int initialCoordinate = 1;
            var compass = Cardinal.South;
            int currentLocation = initialCoordinate;
            int newLocation = 0;
            int i = -1;
            foreach (var command in commands)
            {
                if (int.TryParse(command, out int meterDiff))
                {
                    newLocation += SetCoordinateValue(compass, meterDiff);
                    i++;
                    continue;
                }

                if (Enum.TryParse(command, out DirectionTurn direction))
                    compass = CardinalLookup.SetDirection(compass, direction);
            }
            newLocation = i >= 1 ? newLocation - i : newLocation;
            return (newLocation, compass);
        }

        private int SetCoordinateValue(Cardinal compass, int locationDiff)
        {
            var newLocation = 1;
            switch (compass)
            {
                case Cardinal.South:
                    newLocation += (locationDiff * _yScalar); // Add 100 with every meter
                    break;
                case Cardinal.West:
                    newLocation = 1;
                    newLocation -= locationDiff; // subtract 1 with every meter
                    break;
                case Cardinal.North:
                    newLocation -= (locationDiff * _yScalar); // Subtract 100 with every meter
                    break;
                case Cardinal.East:
                    newLocation = 1;
                    newLocation += locationDiff; // Add 1 with every meter
                    break;
            }

            return newLocation; // return new coordinate
        }
    }
}
