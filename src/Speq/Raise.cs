using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Speq
{
    public static class Raise
    {
        public static Matcher<TestDelegate> Exception<T>() where T:Exception
        {
            return new Matcher<TestDelegate>(
                (action) => Assert.Throws<T>(action),
                (action) => Assert.DoesNotThrow(action)
            );
        }

        public static Matcher<TestDelegate> Exception()
        {
            return new Matcher<TestDelegate>(
                (TestDelegate action) => Assert.Throws<Exception>(action),
                (TestDelegate action) => Assert.DoesNotThrow(action)
            );
        }
    }
}
