using MarsRoverApp;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Test
{
    public class RoverCoordinateCalculateTest
    {
        [Fact]
        public void GivenAListOfCommands_WhenTheListCalculatesMoreThan5Actions_ThenOnlyTheFirst5AreExecuted()
        {
            var commands = new List<string>() { "1" , "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            var calculate = new RoverCoordinateCalculate(commands);
            Assert.Equal(501, calculate.AddressCommands().Location);
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheCommandIsSetSouthBy1Meter_ThenTheExpectedCoordinateIs101()
        {
            var commands = new List<string>() { "1" };

            var calculate = new RoverCoordinateCalculate(commands);
            Assert.Equal(101, calculate.AddressCommands().Location);
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheCommandIsSetSouthBy5Meters_ThenTheExpectedCoordinateIs501()
        {
            var commands = new List<string>() { "5" };

            var calculate = new RoverCoordinateCalculate(commands);
            Assert.Equal(501, calculate.AddressCommands().Location);
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheCommandIsSetSouthBy2Plus3Meters_ThenTheExpectedCoordinateIs501()
        {
            var commands = new List<string>() { "2", "3" };

            var calculate = new RoverCoordinateCalculate(commands);
            Assert.Equal(501, calculate.AddressCommands().Location);
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheCommandIZigZag_ThenTheExpectedCoordinateIs501()
        {
            var commands = new List<string>()
            {
                "2", "Left", "3", "Right", "2",
            };

            var calculate = new RoverCoordinateCalculate(commands);
            Assert.Equal(404, calculate.AddressCommands().Location);
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheRoverIsTurnedLeftAndMovedByOneMeter_ThenTheExpectedCoordinateIs2()
        {
            var commands = new List<string>() { "Left", "1" };

            var calculate = new RoverCoordinateCalculate(commands);
            Assert.Equal(2, calculate.AddressCommands().Location);
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheRoverIsTurnedLeftByOneMeterAndByRightByOneMeter_ThenTheExpectedCoordinateIs102()
        {
            var commands = new List<string>()
            {
                "Left", "1",
                "Right", "1"
            };

            var calculate = new RoverCoordinateCalculate(commands);
            Assert.Equal(102, calculate.AddressCommands().Location);
        }
    }
}
