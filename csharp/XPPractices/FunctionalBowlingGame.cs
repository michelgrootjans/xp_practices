using System.Collections.Generic;

namespace XPPractices
{
    public class FunctionalBowlingGame : IBowlingGame
    {
        readonly List<int> rolls = new List<int>();

        public void Roll(int pins)
        {
            rolls.Add(pins);
        }

        public int GetScore()
        {
            return ScoreFor(rolls);
        }

        private static int ScoreFor(IEnumerable<int> rolls, int frame=1)
        {
            if (rolls.Empty()) return 0;
            if (frame > 10) return 0;

            if (rolls.Head() == 10)
                return rolls.Head() + rolls.Head(1) + rolls.Head(2) + ScoreFor(rolls.Tail(1), frame + 1);
            if (rolls.Head() + rolls.Head(1) == 10)
                return rolls.Head() + rolls.Head(1) + rolls.Head(2) + ScoreFor(rolls.Tail(2), frame + 1);
            return rolls.Head() + rolls.Head(1) + ScoreFor(rolls.Tail(2), frame + 1);
        }
    }
}