using System.Collections.Generic;
using ZalandoShop.Models.Model;

namespace ZalandoShop.Services.Translators
{
    static public class FacetTranslators
    {
        static public Facet Translate(Models.Response.Facets.Facet response)
        {
            return new Facet
            {
                Key = response.key,
                Name = response.displayName
            };
        }

        static public List<Models.Model.Facet> Translate(Models.Response.Facets.FacetResponse response)
        {
            List<Models.Model.Facet> translatedFacets = new List<Facet>();
            foreach (var item in response.facets)
            {
                translatedFacets.Add(Translate(item));
            }
            return translatedFacets;
        }
    }
}
