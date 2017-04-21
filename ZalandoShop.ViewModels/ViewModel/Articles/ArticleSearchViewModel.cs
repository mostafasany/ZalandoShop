using GalaSoft.MvvmLight;
using System.Collections.Generic;
using ZalandoShop.Services.Services.Facet;

namespace ZalandoShop.ViewModels.ViewModel
{
    public class ArticleSearchViewModel : ViewModelBase
    {
        public ArticleSearchViewModel(IFacetService facetService)
        {
            _facetService = facetService;
            _facetService.GetAllBrandFamilyFacetAsync();
        }

        #region Members

        IFacetService _facetService;

        #endregion

        #region Properties

        private List<Models.Model.Facet> _Facets;
        public List<Models.Model.Facet> Facets
        {
            get { return _Facets; }
            set { _Facets = value; }
        }

        #endregion

        #region Commands

        #region OnIntializeCommand

        #endregion

        #endregion
    }
}