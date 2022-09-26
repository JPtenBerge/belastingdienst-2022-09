namespace BowlingGame
{
	public class Game
	{
		private int _currentRoll = 0;
		private int[] _rolls = new int[21];

		public void Roll(int pinsDown)
		{
			_rolls[_currentRoll] = pinsDown;
			_currentRoll++;
		}
		public int GetScore()
		{
			int score = 0;
			int roll = 0;
			for (int i = 0; i < 10; i++)
			{
				if (IsStrike(roll))
				{
					score += _rolls[roll];
					score = AddStrikeBonus(score, roll);
					roll++;
				}
				else if (IsSpare(roll))
				{
					score = AddThisFrame(score, roll);
					score = AddSpareBonus(score, roll);
					roll += 2;
				}
				else
				{
					score = AddThisFrame(score, roll);
					roll += 2;
				}
			}
			return score;
		}
		private int AddThisFrame(int score, int roll)
		{
			score += _rolls[roll];
			score += _rolls[roll + 1];
			return score;
		}
		private int AddStrikeBonus(int score, int roll)
		{
			score += _rolls[roll + 1];
			score += _rolls[roll + 2];
			return score;
		}
		private int AddSpareBonus(int score, int roll)
		{
			score += _rolls[roll + 2];
			return score;
		}
		private bool IsStrike(int roll)
		{
			return _rolls[roll] == 10;
		}
		private bool IsSpare(int roll)
		{
			return _rolls[roll] + _rolls[roll + 1] == 10;
		}
	}
}
