using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DaneTests
{
    [TestClass]
    public class DaneTest
    {
        Dane.CirclesList circles = new Dane.CirclesList();

        [TestMethod]
        public void TestAddRemove()
        {
            circles.AddCircle(10, 10, 10, 5, 5, 5);
            circles.AddCircle(20, 20, 20, 10, 10, 10);

            Assert.AreEqual(circles.Count(), 2);

            circles.RemoveCircle(1);

            Assert.AreEqual(circles.Count(), 1);

            circles.RemoveAllCircles();

            Assert.AreEqual(circles.Count(), 0);

        }

        [TestMethod]
        public void TestGetSet()
        {
            circles.AddCircle(10, 10, 10, 5, 5, 5);
            circles.AddCircle(20, 20, 20, 10, 10, 10);

            Assert.AreEqual(circles.GetX(0), 10);
            Assert.AreEqual(circles.GetY(0), 10);

            circles.SetVx(0, 50);
            circles.SetVy(0, 50);

            Assert.AreEqual(circles.GetVx(0), 50);
            Assert.AreEqual(circles.GetVy(0), 50);

            Assert.AreEqual(circles.GetRadius(0), 10);

            Assert.AreEqual(circles.GetMass(0), 5);
        }

        [TestMethod]
        public void TestChangePosition()
        {
            circles.AddCircle(10, 10, 10, 5, 5, 5);
            circles.AddCircle(20, 20, 20, 10, 10, 10);

            circles.ChangePosition(1, 30, 40);

            Assert.AreEqual(circles.GetX(1), 30);
            Assert.AreEqual(circles.GetY(1), 40);


        }
    }
}
