
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogikaTests
{
    [TestClass]
    public class LogikaTest
    {
        Logika.MovingCirclesAPI movingCircles = new Logika.MovingCircles();
        [TestMethod]
        public void TestCreateRemove()
        {
            movingCircles.CreateCircles(5);

            Assert.AreEqual(5, movingCircles.Count());

            movingCircles.StartMoving();
            movingCircles.StopMoving();
            movingCircles.RemoveCircles();

            Assert.AreEqual(0, movingCircles.Count());

        }

        [TestMethod]
        public void TestGet()
        {
            Assert.AreEqual(800, movingCircles.GetWidth());
            Assert.AreEqual(300, movingCircles.GetHeight());

        }
    }
}