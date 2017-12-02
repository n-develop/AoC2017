using System;
using System.Collections.Generic;
using System.Linq;

namespace DayTwo
{
    public class Spreadsheet
    {
        public int GetChecksum(string input)
        {
            var sum = 0;
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var intries = CastToIntegers(line);
                sum += intries.Max() - intries.Min();
            }
            return sum;
        }

        public int SecondStageChecksum(string input)
        {
            var sum = 0;
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var entries = CastToIntegers(line);

                for (int i = 0; i < entries.Count; i++)
                {
                    var others = GetEntriesWithoutIndex(entries, i);

                    var divisible = others.FirstOrDefault(other => (other % entries[i] == 0) || (entries[i] % other == 0));

                    if (divisible != 0)
                    {
                        sum += divisible > entries[i] ? divisible / entries[i] : entries[i] / divisible;
                        break;
                    }

                }
            }
            return sum;
        }

        private static List<int> GetEntriesWithoutIndex(List<int> entries, int i)
        {
            var others = entries.GetRange(0, entries.Count);
            others.RemoveAt(i);
            return others;
        }

        private static List<int> CastToIntegers(string line)
        {
            List<int> intries = new List<int>();
            var entries = line.Split('	', StringSplitOptions.RemoveEmptyEntries);
            foreach (var entry in entries)
            {
                if (int.TryParse(entry, out var number))
                {
                    intries.Add(number);
                }
            }
            return intries;
        }
    }
}
