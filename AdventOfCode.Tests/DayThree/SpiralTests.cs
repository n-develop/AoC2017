using AdventOfCode.DayThree;
using Xunit;

namespace AdventOfCode.Tests.DayThree
{
    public class SpiralTests
    {
        [Theory]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1, 0)]
        public void FindDistance(int target, int expectedDistance)
        {
            var spiral = new Spiral(target);

            var distance = spiral.GetDistance();

            Assert.Equal(expectedDistance, distance);
        }

        [Fact]
        public void RealInput()
        {
            var spiral = new Spiral(368078);

            var distance = spiral.GetDistance();

            Assert.Equal(371, distance);
        }

        [Theory]
        [InlineData(6, 10)]
        [InlineData(133, 133)]
        [InlineData(27, 54)]
        public void SecondStage(int input, int output)
        {
            var spiral = new SpiralStageTwo(199);

            var nextValue = spiral.FindValueSecondStage(input);

            Assert.Equal(output, nextValue);
        }

        [Fact]
        public void RealInputStageTwo()
        {
            var spiral = new SpiralStageTwo(368078);

            var nextValue = spiral.FindValueSecondStage(368078);

            Assert.Equal(369601, nextValue);
        }
    }
}
