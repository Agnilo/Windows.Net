using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyProgram.Provider
{

    public class CatModel
    {
        [JsonProperty("id")]
        public string catId { get; set; }
        public string name { get; set; }
        public string origin { get; set; }
    }

    public class BreedInfoModel
    {

        public string id { get; set; }
        public string name { get; set; }
        public string temperament { get; set; }
        public string origin { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }

    public class BreedModel
    {
        public List<FindBreed> breeds { get; set; }
        public string url { get; set; }

    }

    public class FindBreed
    {
        public string id { get; set; }
        public string name { get; set; }
        public string temperament { get; set; }
        public string origin { get; set; }
        public string description { get; set; }
    }

    public class SearchBreedModal
    {
        public string SelectedId { get; set; }
    }

    public class CategoryInfoModel
    {
        public string url { get; set; }
    }

    public class SearchCategoryModal
    {
        public string categoryName { get; set; }
        public string categoryId { get; set; }
    }

    public class Categories
    {
        public string id { get; set; }
        public string name { get; set; }
    }

}
