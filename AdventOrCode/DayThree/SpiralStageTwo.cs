using System;

namespace AdventOfCode.DayThree
{
    public class SpiralStageTwo
    {
        private int[,] _matrix;
        private int _size;
        private int _center;

        public SpiralStageTwo(int maxValue)
        {
            var squareRoot = Math.Sqrt(maxValue);
            var intSqrt = (int)squareRoot;
            if (intSqrt < squareRoot)
            {
                intSqrt++;
            }
            _size = intSqrt % 2 == 0 ? intSqrt + 1 : intSqrt;
            _center = _size / 2;
        }

        public int FindValueSecondStage(int input)
        {
            _matrix = new int[_size, _size];
            var y = _center;
            var x = _center;

            _matrix[y, x] = 1;
            ++x;
            _matrix[y, x] = GetValueFor(x, y);

            var currentSquareSize = 3;
            while (currentSquareSize <= _size)
            {
                for (int i = 0; i < currentSquareSize - 2; i++)
                {
                    --y;
                    _matrix[y, x] = GetValueFor(x, y);
                    if (_matrix[y, x] >= input)
                    {
                        return _matrix[y, x];
                    }
                }

                for (int i = 0; i < currentSquareSize - 1; i++)
                {
                    --x;
                    _matrix[y, x] = GetValueFor(x, y);
                    if (_matrix[y, x] >= input)
                    {
                        return _matrix[y, x];
                    }
                }

                for (int i = 0; i < currentSquareSize - 1; i++)
                {
                    ++y;
                    _matrix[y, x] = GetValueFor(x, y);
                    if (_matrix[y, x] >= input)
                    {
                        return _matrix[y, x];
                    }
                }
                for (int i = 0; i < currentSquareSize; i++)
                {
                    if (x + 1 >= _size)
                    {
                        break;
                    }
                    ++x;
                    _matrix[y, x] = GetValueFor(x, y);
                    if (_matrix[y, x] >= input)
                    {
                        return _matrix[y, x];
                    }
                }

                currentSquareSize += 2;
            }
            return -1;
        }

        private int GetValueFor(int x, int y)
        {
            int sum = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (IsOutOfBounce(y + i, x + j))
                    {
                        continue;
                    }
                    sum += _matrix[y + i, x + j];
                }
            }
            return sum;
        }

        private bool IsOutOfBounce(int y, int x)
        {
            return y < 0 || x < 0 || x >= _size || y >= _size;
        }
    }
}
