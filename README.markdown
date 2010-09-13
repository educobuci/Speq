##Example

	using System;
	using NUnit.Framework;
	using SpecUnit;

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