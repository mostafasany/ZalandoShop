using Windows.Networking.Connectivity;
using ZalandoShop.Services.Services.Internet;

namespace ZalandoShop.Core.Services.Internet
{
    public class InternetService : IInternetService
    {
        public bool IsInternet()
        {
            var isConnected = false;
            var profile = NetworkInformation.GetInternetConnectionProfile();
            if (profile != null)
                isConnected = profile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
            return isConnected;
        }
    }
}
