using Xunit;

namespace MarsRoverApp
{
    public class RoverTest
    {
        [Fact]
        public void GivenAStartingCardinalOfSouth_WhenTheRoverIsTurnedLeft_ThenTheRoverFacesEast()
        {
            var rover = new Rover(1, Cardinal.South, DirectionTurn.Left);
            Assert.Equal(Cardinal.East, rover.CardinalDirection);
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheRoverIsMovedSouthBy1Meter_ThenTheExpectedCoordinateIs101()
        {
            var rover = new Rover(1, Cardinal.South, DirectionTurn.Left);
            Assert.Equal(101, rover.Location);
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheRoverIsTurnedLeftAndMovedByOneMeter_ThenTheExpectedCoordinateIs2()
        {
            var rover = new Rover(1, Cardinal.South, DirectionTurn.Left);
            Assert.Equal(2, rover.Location);
        }

        [Fact]
        public void GivenAStartingCoordinateOf1_WhenTheRoverIsTurnedLeftByOneMeterAndByRightByOneMeter_ThenTheExpectedCoordinateIs102()
        {
            var rover = new Rover(1, Cardinal.South, DirectionTurn.Left);
            Assert.Equal(102, rover.Location);
        }
    }
}
