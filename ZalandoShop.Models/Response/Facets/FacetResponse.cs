using System.Collections.Generic;

namespace ZalandoShop.Models.Response.Facets
{
    public class FacetResponse
    {
        public string filter { get; set; }
        public List<Facet> facets { get; set; }
    }
}
