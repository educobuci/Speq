using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Speq
{
    public class Match
    {
        public static Matcher<string> Regex(string pattern)
        {
            return new Matcher<string>(
                (input) => Assert.True(System.Text.RegularExpressions.Regex.IsMatch(input, pattern)),
                (input) => Assert.False(System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
            );
        }
    }
}
