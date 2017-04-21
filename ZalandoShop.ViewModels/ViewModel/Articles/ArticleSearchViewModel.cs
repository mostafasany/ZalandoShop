using GalaSoft.MvvmLight;
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

        #endregion

        #region Commands

        #region OnIntializeCommand

        #endregion

        #endregion
    }
}