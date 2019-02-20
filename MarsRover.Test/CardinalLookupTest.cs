using MarsRoverApp;
using Xunit;

namespace MarsRover.Test
{
    public class CardinalLookupTest
    {
        [Fact]
        public void GivenASouthFacingCardinal_When_ATurnLeftIsMade_ThenCardinalFacesEast()
        {
            Assert.Equal(Cardinal.East, CardinalLookup.SetDirection(Cardinal.South, DirectionTurn.Left));
        }

        [Fact]
        public void GivenASouthFacingCardinal_WhenATurnRightIsMade_ThenCardinalFacesWest()
        {
            Assert.Equal(Cardinal.West, CardinalLookup.SetDirection(Cardinal.South, DirectionTurn.Right));
        }

        [Fact]
        public void GivenANorthFacingCardinal_WhenATurnRightIsMade_ThenCardinalFacesWest()
        {
            Assert.Equal(Cardinal.West, CardinalLookup.SetDirection(Cardinal.North, DirectionTurn.Left));
        }

        [Fact]
        public void GivenANorthFacingCardinal_WhenATurnLeftIsMade_ThenCardinalFacesWest()
        {
            Assert.Equal(Cardinal.East, CardinalLookup.SetDirection(Cardinal.North, DirectionTurn.Right));
        }

        [Fact]
        public void GivenAWestFacingCardinal_WhenATurnLeftIsMade_ThenCardinalFacesSouth()
        {
            Assert.Equal(Cardinal.South, CardinalLookup.SetDirection(Cardinal.West, DirectionTurn.Left));
        }

        [Fact]
        public void GivenAWestFacingCardinal_WhenATurnRightIsMade_ThenCardinalFacesNorth()
        {
            Assert.Equal(Cardinal.North, CardinalLookup.SetDirection(Cardinal.West, DirectionTurn.Right));
        }

        [Fact]
        public void GivenAEastFacingCardinal_WhenATurnLeftIsMade_ThenCardinalFacesNorth()
        {
            Assert.Equal(Cardinal.North, CardinalLookup.SetDirection(Cardinal.East, DirectionTurn.Left));
        }

        [Fact]
        public void GivenAEastFacingCardinal_WhenATurnRightIsMade_ThenCardinalFacesSouth()
        {
            Assert.Equal(Cardinal.South, CardinalLookup.SetDirection(Cardinal.East, DirectionTurn.Right));
        }
    }
}
