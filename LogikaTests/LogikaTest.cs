using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogikaTests
{
    [TestClass]
    public class LogikaTest
    {
        [TestMethod]
        public void TestMethod()
        {

            Logika.IMovingCircles movingCircles = new Logika.MovingCircles();
            movingCircles.CreateCircles(5);

            Assert.AreEqual(5, movingCircles.Count());

            movingCircles.StartMoving();
            movingCircles.StopMoving();
            movingCircles.RemoveCircles();

            Assert.AreEqual(0, movingCircles.Count());
            Assert.AreEqual(800, movingCircles.GetWidth());
            Assert.AreEqual(300, movingCircles.GetHeight());

        }
    }
}