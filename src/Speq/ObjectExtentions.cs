using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Speq
{
    public static class SpecExtentions
    {
        public static void Should<T>(this T target, Matcher<T> validator)
        {
            validator.ShouldTestMethod(target);
        }

        public static void ShouldNot<T>(this T target, Matcher<T> validator)
        {
            validator.ShouldNotTestMethod(target);
        }
    }
}