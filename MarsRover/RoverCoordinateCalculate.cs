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
        public int column = 100; //Save value?
        private IEnumerable<string> commands;
        private readonly int _yScalar = 100;
        private readonly int _xScalar = 1; // 1 + previous value

        public RoverCoordinateCalculate(IEnumerable<string> commands)
        {
            this.commands = commands;
        }

        public int OrganiseSets()
        {
            //Inits
            var final = new List<int>();
            int numbers = 1; // Save values?
            int initialCoordinate = 1;
            int finalCoordinate = 1;
            Cardinal card = Cardinal.South;

            foreach (var command in commands)
            {
                int currentValue = initialCoordinate;
                
                if (int.TryParse(command, out int meters))
                {
                    numbers += SetCoordinateValue(card, meters);
                    // Combine all meter ranges between direction changes
                    continue;
                }

                // If direction has changed, set the column
                if (Enum.TryParse(command, out DirectionTurn direction))
                    card = CardinalLookup.SetDirection(card, direction);
            }
            finalCoordinate = numbers;
            return finalCoordinate;
        }

        private int SetCoordinateValue(Cardinal cardinal, int currentValue)
        {
            switch (CardinalLookup.SetDirection(cardinal, DirectionTurn.None))
            {
                case Cardinal.South:
                    currentValue *= _yScalar; // Add 100 with every meter
                    break;
                case Cardinal.West:
                    currentValue -= _xScalar; // subtract 1 with every meter
                    break;
                case Cardinal.North:
                    currentValue /= _yScalar; // Subtract 100 with every meter
                    break;
                case Cardinal.East:
                    currentValue += _xScalar; // Add 1 with every meter
                    break;
            }

            return currentValue; // return new coordinate
        }
    }
}
