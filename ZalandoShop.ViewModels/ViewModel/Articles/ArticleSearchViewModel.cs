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
            PopulateGenderList();
        }

        #region Members

        IFacetService _facetService;
        INavigationService _navigationService;
        #endregion

        #region Properties

        private List<Models.Model.Gender> _GenderList;
        public List<Models.Model.Gender> GenderList
        {
            get { return _GenderList; }
            set { _GenderList = value; RaisePropertyChanged(); }
        }

        private Gender _SelectedGender;
        public Gender SelectedGender
        {
            get { return _SelectedGender; }
            set { _SelectedGender = value; RaisePropertyChanged(); }
        }

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

        #region Private Methods

        private void PopulateGenderList()
        {
            GenderList = new List<Gender>();
            GenderList.Add(new Gender { Id = 1, Name = "MEN", Image = "/Assets/Gender/Male.png" });
            GenderList.Add(new Gender { Id = 2, Name = "WOMEN", Image = "/Assets/Gender/Female.png" });
            SelectedGender = GenderList.FirstOrDefault();
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
                if (Facets == null || Facets.Count == 0)
                {
                    Facets = await _facetService.GetAllBrandFamilyFacetAsync();
                    FilterText = "";
                }

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

        private void OnFacetSelected(Facet facet)
        {
            var paramters = new FacetSearch { Gender = SelectedGender, Search = facet.Name };
            _navigationService.Navigate(Models.Enum.PageType.ArticlesSearchResult, paramters);
        }
        #endregion

        #region OnSearchCommand

        RelayCommand _OnSearchCommand;
        public RelayCommand OnSearchCommand
        {
            get
            {
                if (_OnSearchCommand == null)
                    _OnSearchCommand = new RelayCommand(OnSearch);
                return _OnSearchCommand;
            }
        }

        private void OnSearch()
        {
            var paramters = new FacetSearch { Gender = SelectedGender, Search = FilterText };
            _navigationService.Navigate(Models.Enum.PageType.ArticlesSearchResult, paramters);
        }
        #endregion

        #endregion
    }
}