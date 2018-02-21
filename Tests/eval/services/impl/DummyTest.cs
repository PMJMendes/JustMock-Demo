using EvalApp.services.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvalApp.services.impl
{
    [TestClass]
    public class DummyTest
    {
        [TestMethod]
        public void EvalTestGetStuff()
        {
            IDummy service = new DummyImpl();

            var result = service.GetStuff();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("ABC", result[0]);
            Assert.AreEqual("DEF", result[1]);
        }
    }
}
