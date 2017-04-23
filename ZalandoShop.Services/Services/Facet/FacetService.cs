using System.Collections.Generic;
using System.Threading.Tasks;
using ZalandoShop.Models.Response.Facets;
using ZalandoShop.Services.Services.Network;
using ZalandoShop.Services.Translators;

namespace ZalandoShop.Services.Services.Facet
{
    public class FacetService : IFacetService
    {
        public FacetService(INetworkService networkService)
        {
            _networkService = networkService;
        }

        #region Members

        INetworkService _networkService;

        #endregion

        private List<Models.Model.Facet> AllFacets { get; set; }

        public async Task<List<Models.Model.Facet>> GetAllFacetAsync()
        {
            if (AllFacets == null || AllFacets.Count == 0)
            {
                var resource = Constant.ServiceURL.BaseUrl + Constant.ServiceURL.API_Facets;
                var result = await _networkService.HttpGetAsync<List<FacetResponse>>(resource);
                if (result != null && result.Result != null && result.HttpResponseMessage != null && result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    AllFacets = FacetTranslators.Translate(result.Result);
                }
            }
            return AllFacets;
        }

    }
}
