using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace MyProgram.Provider
{
    public class ApiHelper
    {
        private static readonly string baseAddress = "https://api.thecatapi.com/v1/";

        public static IList<CatModel> GetCats()
        {
            using (HttpClient ApiClient = new HttpClient())
            {
                ApiClient.BaseAddress = new Uri(baseAddress);
                string s = ApiClient.GetStringAsync("breeds").Result;
                var list = JsonConvert.DeserializeObject<List<CatModel>>(s);

                return list;
            }
        }


        public IList<BreedInfoModel> GetBreeds(SearchBreedModal model)
        {
            using (HttpClient ApiClient = new HttpClient())
            {
                string jsonResult = ApiClient.GetStringAsync(urlBreedCreator(model)).Result;
                var list = JsonConvert.DeserializeObject<List<BreedModel>>(jsonResult);

                    var propertiesList = list.Select(c => new BreedInfoModel
                    {

                        name = c.breeds[0].name,
                        temperament = c.breeds[0].temperament,
                        origin = c.breeds[0].origin,
                        description = c.breeds[0].description,
                        url = c.url

                    }).ToList();
                    
                    return propertiesList;
            }
        }

        private string urlBreedCreator(SearchBreedModal model)
        {

            StringBuilder url = new StringBuilder(baseAddress);
            url.Append("images/search?breed_ids=");
            if (model.SelectedId != null)
            {
                url.Append(model.SelectedId);
            }
            return url.ToString();
        }

        public static IList<Categories> GetCategories()
        {
            using (HttpClient ApiClient = new HttpClient())
            {
                ApiClient.BaseAddress = new Uri(baseAddress);
                string s = ApiClient.GetStringAsync("categories").Result;
                var list = JsonConvert.DeserializeObject<List<Categories>>(s);

                return list;
            }
        }
        public IList<CategoryInfoModel> GetCategory(SearchCategoryModal model)
        {
            using (HttpClient ApiClient = new HttpClient())
            {
                string jsonResult = ApiClient.GetStringAsync(urlCategoryCreator(model)).Result;
                var list = JsonConvert.DeserializeObject<List<CategoryInfoModel>>(jsonResult);


                var propertiesList = list.Select(c => new CategoryInfoModel
                {
                    url = c.url

                }).ToList();

                return propertiesList;
            }
        }

        private string urlCategoryCreator(SearchCategoryModal model)
        {

            StringBuilder url = new StringBuilder(baseAddress);
            url.Append("images/search?category_ids=");
            if (model.categoryId != null)
            {
                if (model.categoryId == "boxes")
                    url.Append(5);
                if (model.categoryId == "clothes")
                    url.Append(15);
                if (model.categoryId == "hats")
                    url.Append(1);
                if (model.categoryId == "sinks")
                    url.Append(14);
                if (model.categoryId == "space")
                    url.Append(2);
                if (model.categoryId == "sunglasses")
                    url.Append(4);
                if (model.categoryId == "ties")
                    url.Append(7);
            }
            return url.ToString();
        }



    }
}
