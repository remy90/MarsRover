using MarsRoverApp;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTest
    {
        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverIsTurnedLeft_ThenTheRoverFacesEast()
        {
            var commands = new List<string>() { "Left", "1" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.AddressCommands(1, Cardinal.South);
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.East, rover.CardinalDirection);
        }

        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverIsIncrementallyMoved5m_ThenTheRoverIsAt500m()
        {
            var commands = new List<string>() { "1", "1", "1", "1", "1" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.AddressCommands(1, Cardinal.South);
            var rover = new Rover(Location, Compass);

            Assert.Equal(501, rover.Location);
        }

        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverRoamsTheBoundaryAndBack_ThenTheRoverReturnsTo1m()
        {
            var commands = new List<string>() { "99", "Left", "Left", "99" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.AddressCommands(1, Cardinal.South);
            var rover = new Rover(Location, Compass);

            Assert.Equal(1, rover.Location);
        }

        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenHasTheAssignmentExample_ThenTheRoverReturns4624m()
        {
            var commands = new List<string>() { "50", "Left", "23", "Left", "4" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.AddressCommands(1, Cardinal.South);
            var rover = new Rover(Location, Compass);

            Assert.Equal(4624, rover.Location);
            Assert.Equal(Cardinal.North, rover.CardinalDirection);
        }

        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverIsTurnedRightAndTravels50meters_ThenTheRoverFacesEastAtLocation50m()
        {
            var commands = new List<string>() { "Left", "50" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.AddressCommands(1, Cardinal.South);
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.East, rover.CardinalDirection);
            Assert.Equal(51, rover.Location);
        }

        // Edge cases not currently catered for
        // MOD(Location, 100) Gets column
        // Check Column * 100 < val
        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverTravels100meters_ThenTheRoverFacesHaltsAt9901m()
        {
            var commands = new List<string>() { "100" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.AddressCommands(1, Cardinal.South);
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.South, rover.CardinalDirection);
            Assert.Equal(9901, rover.Location);
        }

        [Fact]
        public void Given2ChangesOfDirection_WhenTheRoverTravels101meters_ThenTheRoverFacesHaltsAt9903m()
        {
            var commands = new List<string>() { "Left", "2", "Right", "101" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.AddressCommands(1, Cardinal.South);
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.South, rover.CardinalDirection);
            Assert.Equal(9903, rover.Location);
        }

        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverTurnsLeftAnd101meters_ThenTheRoverFacesHaltsAt100m()
        {
            var commands = new List<string>() { "Left", "101" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.AddressCommands(1, Cardinal.South);
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.East, rover.CardinalDirection);
            Assert.Equal(100, rover.Location);
        }

        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverTurnsRightTwiceAndTravels10meters_ThenTheRoverFacesHaltsAt1m()
        {
            var commands = new List<string>() { "Right", "Right", "10" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.AddressCommands(1, Cardinal.South);
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.North, rover.CardinalDirection);
            Assert.Equal(1, rover.Location);
        }

        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverTurnsRightAndTravels10meters_ThenTheRoverFacesHaltsAt1m()
        {
            var commands = new List<string>() { "Right", "10" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.AddressCommands(1, Cardinal.South);
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.West, rover.CardinalDirection);
            Assert.Equal(1, rover.Location);
        }
    }
}
