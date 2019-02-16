using Xunit;

namespace MarsRoverApp
{
    public class RoverTest
    {
        [Fact]
        public void GivenAStartingCoordinate_WhenTheRoverIsMovedSouth_ThenTheExpectedCoordinateIsCorrect()
        {
            var rover = new Rover(1, Cardinal.South, DirectionTurn.Left);
            Assert.Equal(Cardinal.East, rover.CardinalDirection);
        }
    }
}
