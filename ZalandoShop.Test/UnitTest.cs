using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;
using ZalandoShop.Models.Model;
using ZalandoShop.Services.Services.Article;

namespace ZalandoShop.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Should_Return_Products_When_Search_With_Keyword()
        {
            IArticleService service = ServiceLocator.Current.GetInstance<IArticleService>();
            FacetSearch search = new FacetSearch
            {
                Gender = new Gender() { Id = "male", Name = "Male" },
                Search = "Jeans",
                Facet = null
            };
            var results = await service.GetFilterdArticleAsync(search, 1, 20);
            int count = results.Count;
            Assert.AreNotEqual(0, count);
        }

        [TestMethod]
        public async Task Should_Return_Products_When_Search_With_Filter()
        {
            IArticleService service = ServiceLocator.Current.GetInstance<IArticleService>();
            FacetSearch search = new FacetSearch
            {
                Gender = new Gender() { Id = "male", Name = "Male" },
                Search = "",
                Facet = new Facet { Filter = "brand", Key = "AD1" }
            };
            var results = await service.GetFilterdArticleAsync(search, 1, 20);
            int count = results.Count;
            Assert.AreNotEqual(0, count);
        }

        [TestMethod]
        public async Task Should_Not_Return_Products_When_Search_With_Invalid_Filter()
        {
            IArticleService service = ServiceLocator.Current.GetInstance<IArticleService>();
            FacetSearch search = new FacetSearch
            {
                Gender = new Gender() { Id = "male", Name = "Male" },
                Search = "",
                Facet = new Facet { Filter = "branddd", Key = "AD1" }
            };
            var results = await service.GetFilterdArticleAsync(search, 1, 20);
            int count = results.Count;
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public async Task Should_Not_Return_Products_When_Search_With_Invalid_Gender()
        {
            IArticleService service = ServiceLocator.Current.GetInstance<IArticleService>(); //new ArticleService(new NetworkService());
            FacetSearch search = new FacetSearch
            {
                Gender = new Gender() { Id = "malee", Name = "Male" },
                Search = "",
                Facet = new Facet { Filter = "brand", Key = "AD1" }
            };
            var results = await service.GetFilterdArticleAsync(search, 1, 20);
            int count = results.Count;
            Assert.AreEqual(0, count);
        }
    }
}
