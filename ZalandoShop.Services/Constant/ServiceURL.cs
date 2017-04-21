namespace ZalandoShop.Services.Constant
{
    static public class ServiceURL
    {
        static public readonly string BaseUrl = "https://api.zalando.com";
        static public readonly string API_Facets = "/facets";
        static public readonly string API_Articles = "/articles?brandFamily={0}&category={1}&page={2}&pageSize={3}";
    }
}
