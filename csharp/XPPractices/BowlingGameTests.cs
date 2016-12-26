using NUnit.Framework;

namespace XPPractices
{
    [TestFixture]
    public class BowlingGameTest
    {
        private IBowlingGame game;

        [SetUp]
        public void SetUp()
        {
            game = new BowlingGame();
//            game = new FunctionalBowlingGame();
        }


        [Test]
        public void ANewGame()
        {
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void Rolling0()
        {
            game.Roll(0);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void Rolling1()
        {
            game.Roll(1);
            Assert.AreEqual(1, game.GetScore());
        }

        [Test]
        public void Rolling1Twice()
        {
            game.Roll(1);
            game.Roll(1);
            Assert.AreEqual(2, game.GetScore());
        }

        [Test]
        public void RollingSpare_2()
        {
            game.Roll(6);
            game.Roll(4);
            game.Roll(2);
            Assert.AreEqual(6 + 4 + 2 + 2, game.GetScore());
        }

        [Test]
        public void Rolling_Spares_Spare_2()
        {
            game.Roll(6);
            game.Roll(4);
            game.Roll(7);
            game.Roll(3);
            game.Roll(2);
            Assert.AreEqual(6 + 4 + 7 + 7 + 3 + 2 + 2, game.GetScore());
        }

        [Test]
        public void Rolling_FakeSpares()
        {
            for (var i = 0; i < 21; i++)
            {
                game.Roll(5);
            }
            Assert.AreEqual((5 + 5 + 5) * 10, game.GetScore());
        }

        [Test]
        public void Rolling_Strike_2_3()
        {
            game.Roll(10);
            game.Roll(2);
            game.Roll(3);
            Assert.AreEqual(10 + 2 + 3 + 2 + 3, game.GetScore());
        }

        [Test]
        public void Rolling_Strike_Strike_2_3()
        {
            game.Roll(10);
            game.Roll(10);
            game.Roll(2);
            game.Roll(3);
            Assert.AreEqual(10 + 10 + 2 + 10 + 2 + 3 + 2 + 3, game.GetScore());
        }

        [Test]
        public void Rolling_FakeStrike()
        {
            game.Roll(0);
            game.Roll(10);
            game.Roll(2);
            Assert.AreEqual(0+10+2 + +2, game.GetScore());
        }

        [Test]
        public void Rolling_AllStrikes()
        {
            for (var i = 0; i < 12; i++)
            {
                game.Roll(10);
            }
            Assert.AreEqual((10 + 10 + 10) * 10, game.GetScore());
        }
    }
}