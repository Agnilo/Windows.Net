using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProgram.Provider;
using System.Collections.Generic;

namespace UnitTest
{

    class CategoriesProvider : ICategoryProvider
    {
        public IList<Categories> Category;
        public int GetCategoriesCounter { get; private set; }
        public IList<Categories> GetCategories()
        {
            GetCategoriesCounter++;
            return Category;
        }
    }
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestCashingCategory()
        {
            var testProv = new CategoriesProvider
            {
                Category = new List<Categories>
                {
                    new Categories {
                        name="ties",
                        id=7
                    }
                }
            };
            var cashingProvider = new CategoryCashingProvider(testProv);
            var category1 = cashingProvider.GetCategories();
            Assert.AreEqual(1, testProv.GetCategoriesCounter);

            var category2 = cashingProvider.GetCategories();
            Assert.AreEqual(1, testProv.GetCategoriesCounter);

            Assert.AreEqual(category1, category2);
        }
    }
}
