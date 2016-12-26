using System.Collections.Generic;

namespace XPPractices
{
    public class BowlingGame : IBowlingGame
    {
        private readonly List<int> rolls = new List<int>();
        private bool isFirstRoll = true;

        public void Roll(int pins)
        {
            rolls.Add(pins);
            if (pins == 10 && isFirstRoll)
                rolls.Add(0); // dirty hack to keep the rolls in pairs
            else
                isFirstRoll = !isFirstRoll;
        }

        public int GetScore()
        {
            var score = 0;
            for (var frame = 1; frame <= 10; frame++)
                score += ScoreFor(frame);
            return score;
        }

        private int ScoreFor(int frame)
        {
            if (IsStrike(frame)) return NormalScoreFor(frame) + StrikeBonusFor(frame);
            if (IsSpare(frame))
                return NormalScoreFor(frame) + SpareBonusFor(frame);
            return NormalScoreFor(frame);
        }

        private bool IsStrike(int frame)
        {
            return FirstRollOf(frame) == 10;
        }

        private int StrikeBonusFor(int frame)
        {
            if (IsStrike(frame + 1))
            {
                return FirstRollOf(frame + 1) + FirstRollOf(frame + 2);
            }
            return FirstRollOf(frame + 1) + SecondRollOf(frame + 1);
        }

        private int SpareBonusFor(int frame)
        {
            return FirstRollOf(frame + 1);
        }

        private int NormalScoreFor(int frame)
        {
            return FirstRollOf(frame) + SecondRollOf(frame);
        }

        private bool IsSpare(int frame)
        {
            return FirstRollOf(frame) + SecondRollOf(frame) == 10;
        }

        private int FirstRollOf(int frame)
        {
            return RollAt((frame - 1) * 2);
        }

        private int SecondRollOf(int frame)
        {
            return RollAt((frame - 1) * 2 + 1);
        }

        private int RollAt(int index)
        {
            return index < rolls.Count ? rolls[index] : 0;
        }
    }
}