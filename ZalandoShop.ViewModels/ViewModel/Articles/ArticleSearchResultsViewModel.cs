using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using ZalandoShop.Models.Model;
using ZalandoShop.Services.Services.Article;
using ZalandoShop.Services.Services.DialogService;
using ZalandoShop.Services.Services.Internet;
using ZalandoShop.Services.Services.Navigation;
using ZalandoShop.ViewModels.strings.en_US;

namespace ZalandoShop.ViewModels.ViewModel
{
    public class ArticleSearchResultsViewModel : BaseViewModel
    {
        public ArticleSearchResultsViewModel(IArticleService articleService,
            INavigationService navigationService, IDialogService dialogService, IInternetService internetService)
        {
            _articleService = articleService;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _internetService = internetService;
        }

        #region Members

        IArticleService _articleService;
        INavigationService _navigationService;
        IDialogService _dialogService;
        IInternetService _internetService;
        int pageNo = 1;
        const int pageSize = 20;

        #endregion

        #region Properties

        private bool _NoArticles = false;
        public bool NoArticles
        {
            get { return _NoArticles; }
            set { _NoArticles = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Models.Model.Article> _Articles;
        public ObservableCollection<Models.Model.Article> Articles
        {
            get { return _Articles; }
            set
            {
                _Articles = value;
                RaisePropertyChanged();

            }
        }

        private Article _SelectedArticles;
        public Article SelectedArticles
        {
            get { return _SelectedArticles; }
            set { _SelectedArticles = value; RaisePropertyChanged(); }
        }

        private FacetSearch _FacetSearch;
        public FacetSearch FacetSearch
        {
            get { return _FacetSearch; }
            set { _FacetSearch = value; }
        }

        #endregion

        #region Private Methods



        #endregion

        #region Commands

        #region OnIntializeCommand

        RelayCommand<FacetSearch> _OnIntializeCommand;
        public RelayCommand<FacetSearch> OnIntializeCommand
        {
            get
            {
                if (_OnIntializeCommand == null)
                    _OnIntializeCommand = new RelayCommand<FacetSearch>(OnIntialize);
                return _OnIntializeCommand;
            }
        }

        private async void OnIntialize(FacetSearch search)
        {
            try
            {
                if (!_internetService.IsInternet())
                {
                    await _dialogService.ShowMessage(Resource.NoInternet, Resource.Error);
                    return;
                }
                NoArticles = false;
                FacetSearch = search;
                IsLoading = true;
                IsPageEnabled = false;
                var articles = await _articleService.GetFilterdArticleAsync(FacetSearch, pageNo, pageSize);
                if (articles != null)
                {
                    NoArticles = (articles.Count == 0);
                    Articles = new ObservableCollection<Article>(articles);
                }
                else
                {
                    NoArticles = true;
                    Articles = new ObservableCollection<Article>();
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

        #region OnLoadMoreCommand

        RelayCommand _OnLoadMoreCommand;
        public RelayCommand OnLoadMoreCommand
        {
            get
            {
                if (_OnLoadMoreCommand == null)
                    _OnLoadMoreCommand = new RelayCommand(OnLoadMore);
                return _OnLoadMoreCommand;
            }
        }

        private async void OnLoadMore()
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
                pageNo++;
                var articles = await _articleService.GetFilterdArticleAsync(FacetSearch, pageNo, pageSize);
                if (articles != null)
                {
                    foreach (var article in articles)
                    {
                        Articles.Add(article);
                    }
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

        #endregion
    }
}