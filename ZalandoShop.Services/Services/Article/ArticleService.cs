using System.Collections.Generic;
using System.Threading.Tasks;
using ZalandoShop.Models.Model;
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

        public async Task<List<Models.Model.Article>> GetFilterdArticleAsync(FacetSearch facetSearch,
            int page, int pageSize)
        {
            string resource = "";
            if (facetSearch.Facet != null)
            {
                resource = Constant.ServiceURL.BaseUrl +
                 string.Format(Constant.ServiceURL.API_ArticlesFacet, facetSearch.Facet.Filter, facetSearch.Facet.Key, facetSearch.Gender.Id, page, pageSize);
            }
            else
            {
                resource = Constant.ServiceURL.BaseUrl +
                 string.Format(Constant.ServiceURL.API_ArticlesSearch, facetSearch.Search, facetSearch.Gender.Id, page, pageSize);
            }
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
