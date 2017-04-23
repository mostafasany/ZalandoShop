namespace ZalandoShop.Models.Response.Articles
{
    public class UnitResponse
    {
        public string id { get; set; }
        public string size { get; set; }
        public PriceResponse price { get; set; }
        public OriginalpriceResponse originalPrice { get; set; }
        public bool available { get; set; }
        public int stock { get; set; }
    }
}
