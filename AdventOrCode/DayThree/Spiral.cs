using System;

namespace AdventOfCode.DayThree
{
    public class Spiral
    {
        private readonly int _size;
        private readonly int _center;
        private readonly int _input;

        public Spiral(int maxValue)
        {
            _input = maxValue;
            var squareRoot = Math.Sqrt(maxValue);
            var intSqrt = (int)squareRoot;
            if (intSqrt < squareRoot)
            {
                intSqrt++;
            }
            _size = intSqrt % 2 == 0 ? intSqrt + 1 : intSqrt;
            _center = _size / 2;
        }

        public int GetDistance()
        {
            var y = _center;
            var x = _center;
            var currentValue = 1;

            if (currentValue == _input)
            {
                return DistanceFromCenter(y, x);
            }

            currentValue++;

            var currentSquareSize = 1;
            while (currentSquareSize <= _size)
            {
                for (int i = 0; i < currentSquareSize - 2; i++)
                {
                    --y;
                    if (currentValue == _input)
                    {
                        return DistanceFromCenter(y, x);
                    }
                    currentValue++;
                }

                for (int i = 0; i < currentSquareSize - 1; i++)
                {
                    --x;
                    if (currentValue == _input)
                    {
                        return DistanceFromCenter(y, x);
                    }
                    currentValue++;
                }

                for (int i = 0; i < currentSquareSize - 1; i++)
                {
                    ++y;
                    if (currentValue == _input)
                    {
                        return DistanceFromCenter(y, x);
                    }
                    currentValue++;
                }
                for (int i = 0; i < currentSquareSize; i++)
                {
                    if (x + 1 >= _size)
                    {
                        break;
                    }
                    ++x;
                    if (currentValue == _input)
                    {
                        return DistanceFromCenter(y, x);
                    }
                    currentValue++;
                }

                currentSquareSize += 2;
            }
            return -1;
        }

        private int DistanceFromCenter(int y, int x)
        {
            return Math.Abs(_center - y) + Math.Abs(_center - x);
        }


    }
}
