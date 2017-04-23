namespace ZalandoShop.Models.Response.Articles
{
    public class BrandResponse
    {
        public string key { get; set; }
        public string name { get; set; }
        public string logoUrl { get; set; }
        public string logoLargeUrl { get; set; }
        public BrandfamilyResponse brandFamily { get; set; }
        public string shopUrl { get; set; }
    }
}
