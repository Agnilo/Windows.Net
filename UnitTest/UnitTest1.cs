using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProgram.Provider;
using System.Collections.Generic;

namespace UnitTest
{

    class CatTestProvider : ICatProvider
    {
        public IList<CatModel> Cats;
        public int GetCatsCounter { get; private set; }
        public IList<CatModel> GetCats()
        {
            GetCatsCounter++;
            return Cats;
        }
    }
    
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCashingCat()
        {
            var testProv = new CatTestProvider
            {
                Cats = new List<CatModel>
                {
                    new CatModel { catId="NaN", name = "WildCat", origin ="None"}
                }
            };
            var cashingProvider = new CatCashingProvider(testProv);
            var cats1 = cashingProvider.GetCats();
            Assert.AreEqual(1, testProv.GetCatsCounter);

            var cats2 = cashingProvider.GetCats();
            Assert.AreEqual(1, testProv.GetCatsCounter);

            Assert.AreEqual(cats1, cats2);
        }

    }
}
