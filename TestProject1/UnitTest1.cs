using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSubtract()
        {
            Wspolbiezne.Calculator x = new Wspolbiezne.Calculator();
            int y = x.Subtract(2, 1);
            Assert.AreEqual(1, y);
        }
    }
}