using System;
using NUnit.Framework;
using Speq;

namespace Tests
{
	[TestFixture]
	public class BeTests:AssertionHelper
	{
		[Test]
		public void EqualityTest()
		{
			TestMatcher("", Be.Equal(""), "different");
		}
		
		[Test]
		public void NullabilityTest()
		{
			TestMatcher(null, Be.Null(), new object());
		}
		
		[Test]
		public void GreaterThanComparationTest()
		{
			TestMatcher(2, Be.Greater(1), 0);
		}
		
		[Test]
		public void LessThanComparationTest()
		{
			TestMatcher(0, Be.Less(1), 2);
		}
		
		[Test]
		public void Emptiness()
		{
			TestMatcher("", Be.Empty(), "not_empty");
		}
		
		[Test]
		public void TrueTest()
		{
			TestMatcher(true, Be.True(), false);
		}
		
		[Test]
		public void FalseTest()
		{
			TestMatcher(false, Be.False(), true);
		}

        [Test]
        public void RegexTest()
        {
            TestMatcher("abc", Match.Regex("[a-c]"), "def");
        }


        [Test]
        public void RaiseExceptionTest()
        {
            TestMatcher(() => { throw new Exception(); }, Raise.Exception(), () => { });
        }

        [Test]
        public void RaiseExceptionOfTypeTest()
        {
            TestMatcher(() => { throw new InvalidOperationException(); }, Raise.Exception<InvalidOperationException>(), () => { });
        }

        [Test]
        public void ContainsTest()
        {
            TestMatcher("abc", Speq.Contains.Text("b"), "d");
        }
		
		private void TestMatcher<T>(T target, Matcher<T> matcher, T unexpected)
		{
			// Should
			Assert.DoesNotThrow(() =>  matcher.ShouldTestMethod(target));
			Assert.Throws<AssertionException>( () =>  matcher.ShouldTestMethod(unexpected));
			
			// ShouldNot
			Assert.DoesNotThrow(() =>  matcher.ShouldNotTestMethod(unexpected));
			Assert.Throws<AssertionException>( () =>  matcher.ShouldNotTestMethod(target));
		}
	}
}