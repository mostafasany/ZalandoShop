using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZalandoShop.Models.Model;
using ZalandoShop.Services.Services.Article;
using ZalandoShop.Services.Services.DialogService;
using ZalandoShop.Services.Services.Navigation;

namespace ZalandoShop.ViewModels.ViewModel
{
    public class ArticleSearchResultsViewModel : BaseViewModel
    {
        public ArticleSearchResultsViewModel(IArticleService articleService,
            INavigationService navigationService, IDialogService dialogService)
        {
            _articleService = articleService;
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        #region Members

        IArticleService _articleService;
        INavigationService _navigationService;
        IDialogService _dialogService;
        int pageNo = 1;
        const int pageSize = 20;
        #endregion

        #region Properties

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
                FacetSearch = search;
                IsLoading = true;
                IsPageEnabled = false;
                var articles = await _articleService.GetFilterdArticleAsync(FacetSearch.Search, "", FacetSearch.Gender.Name, pageNo, pageSize);
                Articles = new ObservableCollection<Article>(articles);
            }
            catch (System.Exception ex)
            {
                await _dialogService.ShowMessage(ex.Message, "Error!");
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
                IsLoading = true;
                IsPageEnabled = false;
                pageNo++;
                var articles = await _articleService.GetFilterdArticleAsync(FacetSearch.Search, "", FacetSearch.Gender.Name, pageNo, pageSize);
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
                await _dialogService.ShowMessage(ex.Message, "Error!");
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