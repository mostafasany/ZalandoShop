using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
using ZalandoShop.Models.Model;
using ZalandoShop.Services.Services.Facet;
using ZalandoShop.Services.Services.Navigation;

namespace ZalandoShop.ViewModels.ViewModel
{
    public class ArticleSearchViewModel : BaseViewModel
    {
        public ArticleSearchViewModel(IFacetService facetService, INavigationService navigationService)
        {
            _facetService = facetService;
            _navigationService = navigationService;
        }

        #region Members

        IFacetService _facetService;
        INavigationService _navigationService;
        #endregion

        #region Properties

        private List<Models.Model.Facet> _Facets;
        public List<Models.Model.Facet> Facets
        {
            get { return _Facets; }
            set { _Facets = value; RaisePropertyChanged(); }
        }

        string _FilterText;
        public string FilterText
        {
            set
            {
                _FilterText = value;
                RaisePropertyChanged();
                RaisePropertyChanged(() => FilteredFacets);
            }
            get
            {
                return _FilterText;
            }
        }


        public List<Models.Model.Facet> FilteredFacets
        {
            get
            {
                if (Facets != null)
                    return Facets.Where(a => a.Name.ToLower().Contains(FilterText.ToLower())).ToList();
                return new List<Models.Model.Facet>();
            }
        }

        #endregion

        #region Commands

        #region OnIntializeCommand

        RelayCommand _OnIntializeCommand;
        public RelayCommand OnIntializeCommand
        {
            get
            {
                if (_OnIntializeCommand == null)
                    _OnIntializeCommand = new RelayCommand(OnIntialize);
                return _OnIntializeCommand;
            }
        }

        private async void OnIntialize()
        {
            try
            {
                IsLoading = true;
                IsPageEnabled = false;
                Facets = await _facetService.GetAllBrandFamilyFacetAsync();
            }
            catch (System.Exception)
            {
            }
            finally
            {
                IsLoading = false;
                IsPageEnabled = true;
            }

        }
        #endregion

        #region OnFacetSelectedCommand

        RelayCommand<Facet> _OnFacetSelectedCommand;
        public RelayCommand<Facet> OnFacetSelectedCommand
        {
            get
            {
                if (_OnFacetSelectedCommand == null)
                    _OnFacetSelectedCommand = new RelayCommand<Facet>(OnFacetSelected);
                return _OnFacetSelectedCommand;
            }
        }

        private async void OnFacetSelected(Facet facet)
        {
            try
            {
                IsLoading = true;
                IsPageEnabled = false;
                _navigationService.Navigate(Models.Enum.PageType.ArticlesSearchResult);
            }
            catch (System.Exception)
            {
            }
            finally
            {
                IsLoading = false;
                IsPageEnabled = true;
            }

        }
        #endregion

        #endregion
    }
}