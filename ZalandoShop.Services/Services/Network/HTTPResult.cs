using System.Net.Http;

namespace ZalandoShop.Services.Services.Network
{
    public class HttpResult<T>
    {
        public HttpResult(T result, HttpResponseMessage httpResponseMessage)
        {
            Result = result;
            HttpResponseMessage = httpResponseMessage;
        }

        public T Result { get; private set; }
        public HttpResponseMessage HttpResponseMessage { get; private set; }

    }
}
