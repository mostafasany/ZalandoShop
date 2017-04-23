using System.Threading.Tasks;

namespace ZalandoShop.Services.Services.Network
{
    public interface INetworkService
    {
        Task<HttpResult<T>> HttpGetAsync<T>(string url) where T : class;
    }
}
