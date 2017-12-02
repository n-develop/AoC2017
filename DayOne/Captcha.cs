namespace DayOne
{
    public class Captcha
    {
        public int Solve(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int currentDigit = -1;
                int nextDigit = -1;
                if (int.TryParse(input[i].ToString(), out currentDigit))
                {
                    var nextIndex = i + 1;

                    if (i == input.Length - 1)
                    {
                        nextIndex = 0;
                    }

                    if (int.TryParse(input[nextIndex].ToString(), out nextDigit) && currentDigit == nextDigit)
                    {
                        sum += currentDigit;
                    }
                }
            }
            return sum;
        }

        public int SolveStageTwo(string input)
        {
            int sum = 0;
            int indexSteps = input.Length / 2;
            for (int i = 0; i < input.Length; i++)
            {
                int currentDigit = -1;
                int nextDigit = -1;
                if (int.TryParse(input[i].ToString(), out currentDigit))
                {
                    var nextIndex = GetNextIndex(i, indexSteps, input.Length - 1);

                    if (int.TryParse(input[nextIndex].ToString(), out nextDigit) && currentDigit == nextDigit)
                    {
                        sum += currentDigit;
                    }
                }
            }
            return sum;
        }

        private static int GetNextIndex(int i, int steps, int lastIndex)
        {
            if (i < steps)
            {
                return i + steps;
            }

            return (i + steps) - (lastIndex + 1);
        }
    }
}
