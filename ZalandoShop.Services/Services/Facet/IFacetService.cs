using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZalandoShop.Services.Services.Facet
{
    public interface IFacetService
    {
        Task<List<Models.Model.Facet>> GetAllBrandFamilyFacetAsync();
    }
}
