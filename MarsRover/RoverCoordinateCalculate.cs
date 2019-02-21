using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverApp
{
    public class RoverCoordinateCalculate
    {
        /// <summary>
        /// Sets the Coordinates for the rover
        /// </summary>
        /// <returns></returns>
        private readonly IEnumerable<string> originalCommands;
        private readonly int _yScalar = 100;

        public RoverCoordinateCalculate(IEnumerable<string> commands)
        {
            originalCommands = commands;
        }

        public (int Location, Cardinal Compass) OrganiseSets()
        {
            int initialCoordinate = 1;
            var compass = Cardinal.South;
            int currentLocation = initialCoordinate;
            int newLocation = 0;
            int incrementCheck = -1;
            bool exceedsCommandLimit = originalCommands.Count() > 5;
            int tempLocation = 0;
            var newCommands = Enumerable.Empty<string>();

            if (exceedsCommandLimit)
            {
                newCommands = originalCommands.Take(5);
                Console.WriteLine("Number of commands exceeded maximum of 5, only first 5 are now applied");
            }
            else
                newCommands = originalCommands;
            
            foreach (var command in newCommands)
            {
                if (int.TryParse(command, out int meterDiff))
                {
                    tempLocation = SetCoordinateValue(compass, meterDiff);
                    SetBoundaryCheck(tempLocation);
                    newLocation += SetBoundaryCheck(tempLocation) ? tempLocation : 0;
                    incrementCheck++;
                    continue;
                }

                if (Enum.TryParse(command, out DirectionTurn direction))
                    compass = CardinalLookup.SetDirection(compass, direction);
            }

            newLocation = incrementCheck >= 1 ? newLocation - incrementCheck : newLocation;
            return (newLocation, compass);
        }

        private bool SetBoundaryCheck(int tempLocation)
        {
            return true;
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

            return newLocation;
        }
    }
}
