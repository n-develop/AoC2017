﻿using System;
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
