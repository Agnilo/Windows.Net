using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProgram.Provider;
using System.Collections.Generic;

namespace UnitTest
{

    class BreedTestProvider : IBreedProvider
    {
        public IList<BreedInfoModel> Breeds;
        public int GetBreedsCounter { get; private set; }
        public IList<BreedInfoModel> GetBreeds()
        {
            GetBreedsCounter++;
            return Breeds;
        }
    }
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestCashingBreed()
        {
            var testProv = new BreedTestProvider
            {
                Breeds = new List<BreedInfoModel>
                {
                    new BreedInfoModel {
                        id="abys",
                        name="Abyssinian",
                        temperament="Active, Energetic, Independent, Intelligent, Gentle",
                        origin = "Egypt",
                        description = "The Abyssinian is easy to care for, and a joy to have in your home. They’re affectionate cats and love both people and other animals.",
                        url="https://cdn2.thecatapi.com/images/0XYvRd7oD.jpg"
                    }
                }
            };
            var cashingProvider = new BreedCashingProvider(testProv);
            var breed1 = cashingProvider.GetBreeds();
            Assert.AreEqual(1, testProv.GetBreedsCounter);

            var breed2 = cashingProvider.GetBreeds();
            Assert.AreEqual(1, testProv.GetBreedsCounter);

            Assert.AreEqual(breed1, breed2);
        }
    }
}
