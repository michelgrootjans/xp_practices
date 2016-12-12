using NUnit.Framework;

namespace XPPractices
{
    [TestFixture]
    public class MyFirstTest
    {
        [Test]
        public void ShouldWork()
        {
            Assert.AreEqual(1+1, 2);
        }
    }
}