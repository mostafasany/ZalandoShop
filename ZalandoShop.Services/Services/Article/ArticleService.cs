using System.Collections.Generic;
using System.Threading.Tasks;
using ZalandoShop.Models.Response;
using ZalandoShop.Services.Services.Network;
using ZalandoShop.Services.Translators;

namespace ZalandoShop.Services.Services.Article
{
    public class ArticleService : IArticleService
    {
        public ArticleService(INetworkService networkService)
        {
            _networkService = networkService;
        }

        #region Members

        INetworkService _networkService;

        #endregion
        public async Task<List<Models.Model.Article>> GetFilterdArticleAsync(string brandFamily, string color,
            string category, int page, int pageSize)
        {
            var resource = Constant.ServiceURL.BaseUrl +
                string.Format(Constant.ServiceURL.API_Articles, brandFamily, category, page, pageSize);
            var result = await _networkService.HttpGetAsync<ArticlesResponse>(resource);
            if (result != null && result.Result != null && result.HttpResponseMessage != null && result.HttpResponseMessage.IsSuccessStatusCode)
            {
                var articles = ArticleTranslator.Translate(result.Result);
                return articles;
            }
            return new List<Models.Model.Article>();
        }
    }
}
