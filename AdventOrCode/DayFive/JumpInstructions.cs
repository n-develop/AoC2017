namespace AdventOfCode.DayFive
{
    public class JumpInstructions
    {
        public static int GetStepsSecondStage(int[] instructions)
        {
            var currentIndex = 0;
            var steps = 0;
            while (currentIndex >= 0 && currentIndex < instructions.Length)
            {
                var offset = instructions[currentIndex];
                if (offset >= 3)
                {
                    instructions[currentIndex] -= 1;
                }
                else
                {
                    instructions[currentIndex] += 1;
                }
                currentIndex += offset;
                steps++;
            }
            return steps;
        }

        public static int GetSteps(int[] instructions)
        {
            var currentIndex = 0;
            var steps = 0;
            while (currentIndex >= 0 && currentIndex < instructions.Length)
            {
                var offset = instructions[currentIndex];
                instructions[currentIndex] += 1;
                currentIndex += offset;
                steps++;
            }
            return steps;
        }
    }
}
