namespace ZalandoShop.Services.Constant
{
    static public class ServiceURL
    {
        static public readonly string BaseUrl = "https://api.zalando.com";
        static public readonly string API_Facets = "/facets";
        static public readonly string API_ArticlesFacet = "/articles?{0}={1}&gender={2}&page={3}&pageSize={4}";
        static public readonly string API_ArticlesSearch = "/articles?fullText={0}&gender={1}&page={2}&pageSize={3}";
    }
}
