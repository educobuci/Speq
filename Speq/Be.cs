using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Speq
{
    public static class Be
    {
		private static Action<bool> assert = Assert.True;
		
        public static Matcher<T> Equal<T>(T to)
        {
            return new Matcher<T>(
                (target) => assert(target.Equals(to)),
                (target) => assert(!target.Equals(to)));
        }
		
        public static Matcher<T> Greater<T>(T than) where T : IComparable
        {
            return new Matcher<T>(
                (target) => Assert.Greater(target, than),
                (target) => Assert.LessOrEqual(target, than));
        }
		
		public static Matcher<T> Less<T>(T than) where T : IComparable
        {
            return new Matcher<T>(
                (target) => Assert.Less(target, than),
                (target) => Assert.GreaterOrEqual(target, than));
        }

        public static Matcher<string> Empty()
        {
            return new Matcher<string>(
                (target) => Assert.IsEmpty(target),
                (target) => Assert.IsNotEmpty(target));
        }

        public static Matcher<object> Null()
        {
            return new Matcher<object>(
                (target) => Assert.Null(target),
                (target) => Assert.NotNull(target));
        }

        public static Matcher<bool> True()
        {
            return new Matcher<bool>(
                (target) => Assert.True(target),
                (target) => Assert.False(target));
        }

        public static Matcher<bool> False()
        {
            return new Matcher<bool>(
                (target) => Assert.False(target),
                (target) => Assert.True(target));
        }
    }
}
