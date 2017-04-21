using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalandoShop.Models.Model;
using ZalandoShop.Models.Response.Facets;
using ZalandoShop.Services.Services.Network;

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

        private List<FacetResponse> AllFacets { get; set; }

        private async Task GetAllFacetAsync()
        {
            var resource = Constant.ServiceURL.BaseUrl + Constant.ServiceURL.API_Facets;
            var result = await _networkService.HttpGetAsync<List<FacetResponse>>(resource);
            if (result != null && result.Result != null && result.HttpResponseMessage != null && result.HttpResponseMessage.IsSuccessStatusCode)
            {
                AllFacets = result.Result;
            }
        }

        public async Task<List<Models.Model.Facet>> GetAllBrandFamilyFacetAsync()
        {
            if (AllFacets == null || AllFacets.Count == 0)
                await GetAllFacetAsync();

            var brandFamiltFacets = AllFacets.Where(a => a.filter == "brandfamily");
            //Should make transaltion here
            return new List<Models.Model.Facet>();
        }

    }
}
