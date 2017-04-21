using System.Collections.Generic;
using System.Linq;
using ZalandoShop.Models.Model;

namespace ZalandoShop.Services.Translators
{
    static public class ArticleTranslator
    {
        static public Article Translate(Models.Response.ArticleResponse response)
        {
            return new Article
            {
                Id = response.id,
                Name = response.name,
                Image = response.media.images != null ? response.media.images.FirstOrDefault().largeUrl : "",
                Color = response.color,
                Size = response.units != null ? response.units.FirstOrDefault().size : "",
                Price = response.units != null ? response.units.FirstOrDefault().price.formatted : "",
            };
        }

        static public List<Models.Model.Article> Translate(Models.Response.ArticlesResponse response)
        {
            List<Models.Model.Article> translatedArticles = new List<Article>();
            foreach (var item in response.content)
            {
                translatedArticles.Add(Translate(item));
            }
            return translatedArticles;
        }
    }
}
