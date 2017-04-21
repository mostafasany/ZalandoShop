using System;

namespace ZalandoShop.Models.Response
{
    public class ArticlesResponse
    {
        public ArticleResponse[] content { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }

    public class ArticleResponse
    {
        public string id { get; set; }
        public string modelId { get; set; }
        public string name { get; set; }
        public string shopUrl { get; set; }
        public string color { get; set; }
        public bool available { get; set; }
        public string season { get; set; }
        public string seasonYear { get; set; }
        public DateTime activationDate { get; set; }
        public string[] additionalInfos { get; set; }
        public object[] tags { get; set; }
        public string[] genders { get; set; }
        public string[] ageGroups { get; set; }
        public BrandResponse brand { get; set; }
        public string[] categoryKeys { get; set; }
        public Attribute[] attributes { get; set; }
        public UnitResponse[] units { get; set; }
        public MediaResponse media { get; set; }
    }
}
