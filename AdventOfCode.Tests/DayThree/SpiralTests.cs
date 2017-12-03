using AdventOfCode.DayThree;
using Xunit;

namespace AdventOfCode.Tests.DayThree
{
    public class SpiralTests
    {
        [Theory]
        [InlineData(368078, 607)]
        [InlineData(4, 3)]
        [InlineData(13, 5)]
        [InlineData(17, 5)]
        [InlineData(23, 5)]
        public void DetermineQuareSize(int value, int expectedSize)
        {
            var spiral = new Spiral(value);

            var size = spiral.GetSize();

            Assert.Equal(expectedSize, size);
        }

        [Fact]
        public void BuildMatrix()
        {
            var spiral = new Spiral(24);
            var matrix = new int[,]
            {
                {17, 16, 15, 14, 13},
                {18, 5, 4, 3, 12},
                {19, 6, 1, 2, 11},
                {20, 7, 8, 9, 10},
                {21, 22, 23, 24, 25}
            };

            spiral.BuildMatrix();

            Assert.Equal(matrix, spiral.GetMatrix());
        }

        [Theory]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1, 0)]
        public void FindDistance(int target, int expectedDistance)
        {
            var spiral = new Spiral(25);
            spiral.BuildMatrix();

            var distance = spiral.FindDistance(target);

            Assert.Equal(expectedDistance, distance);
        }

        [Fact]
        public void RealInput()
        {
            var spiral = new Spiral(368078);
            spiral.BuildMatrix();

            var distance = spiral.FindDistance(368078);

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
