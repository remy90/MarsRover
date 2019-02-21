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
            var (Location, Compass) = calculate.OrganiseSets();
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.East, rover.CardinalDirection);
        }

        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverIsIncrementallyMoved5m_ThenTheRoverIsAt500m()
        {
            var commands = new List<string>() { "1", "1", "1", "1", "1" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.OrganiseSets();
            var rover = new Rover(Location, Compass);

            Assert.Equal(501, rover.Location);
        }

        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverRoamsTheBoundaryAndBack_ThenTheRoverReturnsTo1m()
        {
            var commands = new List<string>() { "100", "Left", "Left", "100" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.OrganiseSets();
            var rover = new Rover(Location, Compass);

            Assert.Equal(1, rover.Location);
        }

        [Fact]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverIsTurnedRightAndTravels50meters_ThenTheRoverFacesEastAtLocation50m()
        {
            var commands = new List<string>() { "Left", "50" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.OrganiseSets();
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.East, rover.CardinalDirection);
            Assert.Equal(51, rover.Location);
        }

        // Edge cases not currently catered for
        [Fact(Skip = "not implemented yet")]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverTravels101meters_ThenTheRoverFacesHaltsAt100m()
        {
            var commands = new List<string>() { "101" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.OrganiseSets();
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.East, rover.CardinalDirection);
            Assert.Equal(100, rover.Location);
        }

        [Fact(Skip = "not implemented yet")]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverTurnsLeftAnd101meters_ThenTheRoverFacesHaltsAt100m()
        {
            var commands = new List<string>() { "Left", "101" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.OrganiseSets();
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.South, rover.CardinalDirection);
            Assert.Equal(100, rover.Location);
        }

        [Fact(Skip = "not implemented yet")]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverTurnsRightTwiceAndTravels10meters_ThenTheRoverFacesHaltsAt1m()
        {
            var commands = new List<string>() { "Right", "Right", "10" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.OrganiseSets();
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.North, rover.CardinalDirection);
            Assert.Equal(1, rover.Location);
        }

        [Fact(Skip = "not implemented yet")]
        public void GivenARoverSouthFacingStartingPoint_WhenTheRoverTurnsLeftAndTravels10meters_ThenTheRoverFacesHaltsAt1m()
        {
            var commands = new List<string>() { "Left", "10" };

            var calculate = new RoverCoordinateCalculate(commands);
            var (Location, Compass) = calculate.OrganiseSets();
            var rover = new Rover(Location, Compass);

            Assert.Equal(Cardinal.West, rover.CardinalDirection);
            Assert.Equal(1, rover.Location);
        }
    }
}
