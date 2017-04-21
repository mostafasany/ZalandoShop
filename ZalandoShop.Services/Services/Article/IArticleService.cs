using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZalandoShop.Services.Services.Article
{
    public interface IArticleService
    {
        Task<List<Models.Model.Article>> GetFilterdArticleAsync(string brandFamily, string color,
            string category, int page, int pageSize);
    }
}
