using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Speq
{
    public static class Contains
    {
        public static Matcher<string> Text(string text)
        {
            return new Matcher<string>(
                (input) => Assert.True(input.Contains(text)),
                (input) => Assert.False(input.Contains(text))
            );
        }
    }
}
