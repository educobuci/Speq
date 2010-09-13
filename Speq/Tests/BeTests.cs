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
		public void TestFalse()
		{
			TestMatcher(false, Be.False(), true);
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