using MarsRoverApp;
using System;
using System.Collections.Generic;

namespace MarsRover
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
        readonly int yProduct = 100;
        readonly int _xProduct = 1; // 1 + previous value

        public RoverCoordinateCalculate(IEnumerable<string> commands)
        {
            this.commands = commands;
        }

        public void OrganiseSets()
        {
            //Inits
            var final = new List<int>();
            int numbers = 0; // Save value?
            int initialCoordinate = 1;
            Cardinal card = Cardinal.South;

            foreach (var command in this.commands)
            {
                //Create new list
                if (int.TryParse(command, out int meters))
                {
                    numbers += SetXAndYProduct(card, initialCoordinate);
                    continue;
                }

                final.Add(numbers);
                numbers = 0;

                if (Enum.TryParse(command, out DirectionTurn direction))
                    CardinalLookup.SetDirection(card, direction);
                
                SetXAndYProduct(card, initialCoordinate);
                // if it's not an int, create a new list
            }
        }

        private int SetXAndYProduct(Cardinal cardinal, int currentValue)
        {
            // Y product always equals 100
            // X product changes based on column

            switch (CardinalLookup.SetDirection(cardinal, DirectionTurn.None))
            {
                case Cardinal.South:
                    column = 100 * _xProduct; // Add 100 with every meter
                    break;
                case Cardinal.West:
                    column = 1 - yProduct; // subtract 1 with every meter
                    break;
                case Cardinal.North:
                    column = -100 * _xProduct; // Subtract 100 with every meter
                    break;
                case Cardinal.East:
                    column = 1 + yProduct; // Add 1 with every meter
                    break;
            }

            return currentValue + column; // return new coordinate
        }
    }
}
