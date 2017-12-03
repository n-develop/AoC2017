using System;
using System.Drawing;

namespace AdventOfCode.DayThree
{
    public class Spiral
    {
        private int[,] _matrix;
        private int _size;
        private int _center;

        public Spiral(int maxValue)
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

        public int GetSize()
        {
            return _size;
        }

        public void BuildMatrix()
        {
            _matrix = new int[_size, _size];
            var y = _center;
            var x = _center;
            var value = 1;

            _matrix[y, x] = value++;
            _matrix[y, ++x] = value++;

            var currentSquareSize = 3;
            while (currentSquareSize <= _size)
            {
                for (int i = 0; i < currentSquareSize - 2; i++)
                {
                    _matrix[--y, x] = value++;
                }

                for (int i = 0; i < currentSquareSize - 1; i++)
                {
                    _matrix[y, --x] = value++;
                }

                for (int i = 0; i < currentSquareSize - 1; i++)
                {
                    _matrix[++y, x] = value++;
                }
                for (int i = 0; i < currentSquareSize; i++)
                {
                    if (x + 1 >= _size)
                    {
                        break;
                    }
                    _matrix[y, ++x] = value++;
                }

                currentSquareSize += 2;
            }
        }

        public int[,] GetMatrix()
        {
            return _matrix;
        }

        public int FindDistance(int target)
        {
            var targetValue = FindTargetValue(target);

            return Math.Abs(_center - targetValue.Y) + Math.Abs(_center - targetValue.X);
        }

        private Point FindTargetValue(int target)
        {
            var targetValue = Point.Empty;

            for (int row = 0; row < _matrix.GetLength(0); row++)
            {
                for (int col = 0; col < _matrix.GetLength(1); col++)
                {
                    if (_matrix[row, col] == target)
                    {
                        targetValue.X = col;
                        targetValue.Y = row;
                        return targetValue;
                    }
                }
            }
            return targetValue;
        }
    }
}
