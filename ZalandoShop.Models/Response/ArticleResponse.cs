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

    public class BrandResponse
    {
        public string key { get; set; }
        public string name { get; set; }
        public string logoUrl { get; set; }
        public string logoLargeUrl { get; set; }
        public BrandfamilyResponse brandFamily { get; set; }
        public string shopUrl { get; set; }
    }

    public class BrandfamilyResponse
    {
        public string key { get; set; }
        public string name { get; set; }
        public string shopUrl { get; set; }
    }

    public class MediaResponse
    {
        public ImageResponse[] images { get; set; }
    }

    public class ImageResponse
    {
        public int orderNumber { get; set; }
        public string type { get; set; }
        public string thumbnailHdUrl { get; set; }
        public string smallUrl { get; set; }
        public string smallHdUrl { get; set; }
        public string mediumUrl { get; set; }
        public string mediumHdUrl { get; set; }
        public string largeUrl { get; set; }
        public string largeHdUrl { get; set; }
    }

    public class AttributeResponse
    {
        public string name { get; set; }
        public string[] values { get; set; }
    }

    public class UnitResponse
    {
        public string id { get; set; }
        public string size { get; set; }
        public PriceResponse price { get; set; }
        public OriginalpriceResponse originalPrice { get; set; }
        public bool available { get; set; }
        public int stock { get; set; }
    }

    public class PriceResponse
    {
        public string currency { get; set; }
        public float value { get; set; }
        public string formatted { get; set; }
    }

    public class OriginalpriceResponse
    {
        public string currency { get; set; }
        public float value { get; set; }
        public string formatted { get; set; }
    }

}
