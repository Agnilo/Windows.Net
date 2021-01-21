using System;
using System.Collections.Generic;
using System.Text;

namespace MyProgram.Provider
{
    public interface ICatProvider
    {
        IList<CatModel> GetCats();
    }
    public interface IBreedProvider
    {
        IList<BreedInfoModel> GetBreeds();
    }
    public interface ICategoryProvider
    {
        IList<Categories> GetCategories();
    }
    public class CatCashingProvider : ICatProvider
    {
        private readonly ICatProvider m_provider;
        private IList<CatModel> m_cats = null;

        public CatCashingProvider(ICatProvider provider)
        {
            m_provider = provider;
        }
        public IList<CatModel> GetCats()
        {
            if (m_cats != null)
                return m_cats;
            return m_cats = m_provider.GetCats();
        }
    }

    public class BreedCashingProvider : IBreedProvider
    {
        private readonly IBreedProvider m_provider;
        private IList<BreedInfoModel> m_breeds = null;

        public BreedCashingProvider(IBreedProvider provider)
        {
            m_provider = provider;
        }
        public IList<BreedInfoModel> GetBreeds()
        {
            if (m_breeds != null)
                return m_breeds;
            return m_breeds = m_provider.GetBreeds();
        }
    }
    public class CategoryCashingProvider : ICategoryProvider
    {
        private readonly ICategoryProvider m_provider;
        private IList<Categories> m_category = null;

        public CategoryCashingProvider(ICategoryProvider provider)
        {
            m_provider = provider;
        }
        public IList<Categories> GetCategories()
        {
            if (m_category != null)
                return m_category;
            return m_category = m_provider.GetCategories();
        }
    }

}
