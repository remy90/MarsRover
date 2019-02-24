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
        private readonly IEnumerable<string> commands;
        private readonly int _yScalar = 100;

        public RoverCoordinateCalculate(IEnumerable<string> commands)
        {
            this.commands = commands;
        }

        public (int Location, Cardinal Compass) AddressCommands(int previousLocation, Cardinal previousDirection)
        {
            var compass = previousDirection;
            int location = previousLocation,
                locationAdjustment = 0,
                boundaryLimit = (compass == Cardinal.East || compass == Cardinal.West)
                        ? GetLimitForLatitudinalTravel(compass, location)
                        : GetLimitForLongitudinalTravel(compass, location);
            
            IEnumerable<string> newCommands = ValidatedCommands();

            foreach (var command in newCommands)
            {
                if (int.TryParse(command, out int meterDiff))
                {
                    if (meterDiff < 0)
                    {
                        Console.WriteLine("Negative values are not accepted due to boundary limitations");
                        continue;
                    }

                    locationAdjustment = SetLocationAdjustment(compass, meterDiff);
                    
                    bool perimeterIsReached = GetPerimeterValidation(compass, location + locationAdjustment, boundaryLimit);

                    if (perimeterIsReached)
                    {
                        Console.WriteLine("Rover has reached the permissible limit. All commands have halted");
                        return  (boundaryLimit, compass);
                    }
                    else
                        location += locationAdjustment;

                    continue;
                }

                if (Enum.TryParse(command, true, out DirectionTurn direction))
                {
                    compass = CardinalLookup.SetDirection(compass, direction);

                    boundaryLimit = (compass == Cardinal.East || compass == Cardinal.West)
                        ? GetLimitForLatitudinalTravel(compass, location)
                        : GetLimitForLongitudinalTravel(compass, location);
                }
                else
                    Console.WriteLine($"Command \"{command}\" not recognised");
            }
            
            return (location, compass);
        }

        private IEnumerable<string> ValidatedCommands()
        {
            const int maxNumberOfArguments = 5;
            bool exceedsCommandLimit = commands.Count() > maxNumberOfArguments;
            if (exceedsCommandLimit)
            {
                Console.WriteLine("Number of commands exceeded maximum of 5, only first 5 are now applied");
                return commands.Take(5);
            }

            return commands;
        }

        private bool GetPerimeterValidation(Cardinal compass, int location, int boundaryLimit)
        {
            if (compass == Cardinal.North || compass == Cardinal.West)
                return location < boundaryLimit; // Lower boundary

            return Math.Abs(location) > boundaryLimit; // Upper boundary
        }

        private int GetLimitForLatitudinalTravel(Cardinal compass, int location)
        {
            int column = location == 0 ? 1 : location % 100,
                cellRow = (location / 100 ) + 1,
                upperLimit = cellRow * 100,
                lowerLimit = upperLimit - 99;

            return compass == Cardinal.East? upperLimit : lowerLimit;
        }

        private int GetLimitForLongitudinalTravel(Cardinal compass, int location)
        {
            const int furthestLocation = 10000,
                columnMax = 100,
                columnMin = 1;

            int column = location == 0 ? columnMin : location % columnMax,
                upperLimit = furthestLocation - (columnMax - column),
                lowerLimit = column == 0 ? columnMin : column;

            return compass == Cardinal.South ? upperLimit : lowerLimit;
        }

        private int SetLocationAdjustment(Cardinal compass, int locationDiff)
        {
            var newLocation = 0;
            switch (compass)
            {
                case Cardinal.South:
                    newLocation += (locationDiff * _yScalar); // Add 100 with every meter
                    break;
                case Cardinal.West:
                    newLocation -= locationDiff; // subtract 1 with every meter
                    break;
                case Cardinal.North:
                    newLocation -= (locationDiff * _yScalar); // Subtract 100 with every meter
                    break;
                case Cardinal.East:
                    newLocation += locationDiff; // Add 1 with every meter
                    break;
            }

            return newLocation;
        }
    }
}
