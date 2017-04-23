using System.Collections.Generic;
using ZalandoShop.Models.Model;

namespace ZalandoShop.Services.Translators
{
    static public class FacetTranslators
    {
        static public Facet Translate(Models.Response.Facets.Facet response, string filter)
        {
            if (response == null)
                return new Facet();

            return new Facet
            {
                Key = response.key,
                Name = response.displayName,
                Filter = filter,
            };
        }

        static public List<Facet> Translate(List<Models.Response.Facets.FacetResponse> response)
        {
            List<Facet> translatedFacets = new List<Facet>();
            foreach (var facetResponse in response)
            {
                if (facetResponse == null)
                    continue;

                foreach (var facet in facetResponse.facets)
                {
                    translatedFacets.Add(Translate(facet, facetResponse.filter));
                }
            }
            return translatedFacets;
        }
    }
}
