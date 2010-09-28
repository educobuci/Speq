using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Speq
{
    public class Matcher<T>
    {
        public Matcher(Action<T> should, Action<T> shouldNot)
        {
            this.ShouldTestMethod = should;
            this.ShouldNotTestMethod = shouldNot;
        }
        public Action<T> ShouldTestMethod { get; set; }
        public Action<T> ShouldNotTestMethod { get; set; }
    }
}
