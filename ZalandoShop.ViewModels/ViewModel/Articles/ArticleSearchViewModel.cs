using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
using ZalandoShop.Models.Model;
using ZalandoShop.Services.Services.DialogService;
using ZalandoShop.Services.Services.Facet;
using ZalandoShop.Services.Services.Internet;
using ZalandoShop.Services.Services.Navigation;
using ZalandoShop.ViewModels.strings.en_US;

namespace ZalandoShop.ViewModels.ViewModel
{
    public class ArticleSearchViewModel : BaseViewModel
    {
        public ArticleSearchViewModel(IFacetService facetService,
            INavigationService navigationService, IDialogService dialogService, IInternetService internetService)
        {
            _facetService = facetService;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _internetService = internetService;
            PopulateGenderList();
        }

        #region Members

        IFacetService _facetService;
        INavigationService _navigationService;
        IDialogService _dialogService;
        IInternetService _internetService;
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
            GenderList.Add(new Gender { Id = "male", Name = "MEN", Image = "/Assets/Gender/Male.png" });
            GenderList.Add(new Gender { Id = "female", Name = "WOMEN", Image = "/Assets/Gender/Female.png" });
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
                if (!_internetService.IsInternet())
                {
                    await _dialogService.ShowMessage(Resource.NoInternet, Resource.Error);
                    return;
                }
                IsLoading = true;
                IsPageEnabled = false;
                if (Facets == null || Facets.Count == 0)
                {
                    Facets = await _facetService.GetAllFacetAsync();
                    FilterText = "";
                }

            }
            catch (System.Exception ex)
            {
                await _dialogService.ShowMessage(ex.Message, Resource.Error);
            }
            finally
            {
                IsLoading = false;
                IsPageEnabled = true;
            }
        }

        #endregion

        #region OnFacetSelectedCommand

        RelayCommand<object> _OnFacetSelectedCommand;
        public RelayCommand<object> OnFacetSelectedCommand
        {
            get
            {
                if (_OnFacetSelectedCommand == null)
                    _OnFacetSelectedCommand = new RelayCommand<object>(OnFacetSelected);
                return _OnFacetSelectedCommand;
            }
        }

        private void OnFacetSelected(object obj)
        {
            if (obj is Facet)
            {
                var facet = obj as Facet;
                var paramters = new FacetSearch { Gender = SelectedGender, Facet = facet, Search = null };
                _navigationService.Navigate(Models.Enum.PageType.ArticlesSearchResult, paramters);
            }
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
            var paramters = new FacetSearch { Gender = SelectedGender, Facet = null, Search = FilterText };
            _navigationService.Navigate(Models.Enum.PageType.ArticlesSearchResult, paramters);
        }

        #endregion

        #endregion
    }
}