using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.DayFour
{
    public class Passphrase
    {
        private readonly string _phrase;

        public Passphrase(string phrase)
        {
            this._phrase = phrase;
        }


        public bool IsValid
        {
            get
            {
                var words = _phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                return !ContainsDuplicates(words);
            }
        }

        private static bool ContainsDuplicates(IEnumerable<string> words)
        {
            return words.GroupBy(word => word).Any(group => @group.Count() > 1);
        }

        public bool IsSecure
        {
            get
            {
                var words = _phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(str => new string(str.OrderBy(c => c).ToArray()));
                return !ContainsDuplicates(words);
            }
        }
    }
}
