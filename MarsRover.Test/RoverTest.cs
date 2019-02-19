using MarsRoverApp;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTest
    {
        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheCommandIsSetSouthBy1Meter_ThenTheExpectedCoordinateIs101()
        {
            var commands = new List<string>()
            {
                "1"
            };

            var tmp = new RoverCoordinateCalculate(commands);
            Assert.Equal(101, tmp.OrganiseSets());
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheCommandIsSetSouthBy5Meters_ThenTheExpectedCoordinateIs501()
        {
            var commands = new List<string>()
            {
                "5"
            };

            var tmp = new RoverCoordinateCalculate(commands);
            Assert.Equal(501, tmp.OrganiseSets());
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheCommandIsSetSouthBy2Plus3Meters_ThenTheExpectedCoordinateIs501()
        {
            var commands = new List<string>()
            {
                "2", "3"
            };

            var tmp = new RoverCoordinateCalculate(commands);
            Assert.Equal(501, tmp.OrganiseSets());
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheRoverIsTurnedLeftAndMovedByOneMeter_ThenTheExpectedCoordinateIs2()
        {
            var commands = new List<string>()
            {
                "Left", "1"
            };

            var tmp = new RoverCoordinateCalculate(commands);
            Assert.Equal(2, tmp.OrganiseSets());
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheRoverIsTurnedLeftByOneMeterAndByRightByOneMeter_ThenTheExpectedCoordinateIs102()
        {
            var commands = new List<string>()
            {
                "Left", "1",
                "Right", "1"
            };

            var tmp = new RoverCoordinateCalculate(commands);
            Assert.Equal(102, tmp.OrganiseSets());
        }

        [Fact]
        public void GivenAStartingCardinalOfSouth_WhenTheRoverIsTurnedLeft_ThenTheRoverFacesEast()
        {
            var rover = new Rover(1, Cardinal.South, DirectionTurn.Left);
            Assert.Equal(Cardinal.East, rover.CardinalDirection);
        }
    }
}
