using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverApp
{
    public class RoverApplication
    {
        public void Run() {
            int j = 1;
            const int startingLocation = 1;
            const Cardinal startingDirection = Cardinal.South;
            var rover = new Rover(startingLocation, startingDirection);

            for (int i = 0; i < j; i++)
            {
                Console.WriteLine("Please enter the comma separated list of directions for the rover");
                string argList = Console.ReadLine();

                argList = RemoveWhitespace(argList);

                IEnumerable<string> commands = argList.Split(',').AsEnumerable();
                var roverCalc = new RoverCoordinateCalculate(commands);

                var (Location, Compass) = roverCalc.AddressCommands();
                rover.Location = Location;
                rover.CardinalDirection = Compass;

                Console.WriteLine($"Rover is now at {rover.Location}, facing {rover.CardinalDirection}");
                Console.WriteLine("Any further commands? Y/N");
                string response = Console.ReadLine();

                if (RepeatProcess(response))
                    j ++;
                else
                    return;
            }
        }

        private bool RepeatProcess(string response)
        {
            return (response.ToUpper() == "Y");
        }

        private string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
