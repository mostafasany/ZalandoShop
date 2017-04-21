namespace ZalandoShop.Services.Services.Network
{
    public class HttpResult<T>
    {
        public HttpResult(T result)
        {
            Result = result;
        }
        public T Result { get; private set; }

    }
}
