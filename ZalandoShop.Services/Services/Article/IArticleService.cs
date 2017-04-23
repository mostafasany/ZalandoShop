using System.Collections.Generic;
using System.Threading.Tasks;
using ZalandoShop.Models.Model;

namespace ZalandoShop.Services.Services.Article
{
    public interface IArticleService
    {
        Task<List<Models.Model.Article>> GetFilterdArticleAsync(FacetSearch facetSearch, int page, int pageSize);
    }
}
