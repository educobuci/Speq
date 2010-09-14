##Introduction
This is a simple framwork for BDD in .NET. It is highly inspired by RSpec and uses the NUnit stack runners and assertions.
The goal is to provide a better vacabulary for .NET tests.

##Example

	using System;
	using NUnit.Framework;
	using Speq;

	[TestFixture]
	public class DescribeBowlingGame
	{
		[Test]
		public void It_should_returns_0_for_all_gutter_game()
		{
			var game = new Bowling();
			for (int i = 0; i < 10; i++)
			{
				game.Hit(0);
			}
			game.Score.Should(Be.Equal(0));
		}
	}