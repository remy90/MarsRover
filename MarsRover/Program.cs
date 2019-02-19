using MarsRoverApp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    static class Program
    {
        static void Main(string[] args)
        {
            var argExists = args.Length > 0;
            var argList = string.Empty;

            if (!argExists)
            {
                Console.WriteLine("Please enter the comma separated list of directions for the rover");
                argList = Console.ReadLine();
            }

            argList = RemoveWhitespace(argList);

            IEnumerable<string> commands = argList.Split(',').AsEnumerable();
            var roverCalc = new RoverCoordinateCalculate(commands);

            Console.ReadLine();
        }

        private static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
