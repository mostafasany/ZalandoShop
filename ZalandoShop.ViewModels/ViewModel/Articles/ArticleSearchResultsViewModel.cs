using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
using ZalandoShop.Models.Model;
using ZalandoShop.Services.Services.Article;
using ZalandoShop.Services.Services.Navigation;

namespace ZalandoShop.ViewModels.ViewModel
{
    public class ArticleSearchResultsViewModel : BaseViewModel
    {
        public ArticleSearchResultsViewModel(IArticleService articleService, INavigationService navigationService)
        {
            _articleService = articleService;
            _navigationService = navigationService;
        }

        #region Members

        IArticleService _articleService;
        INavigationService _navigationService;
        #endregion

        #region Properties

        private List<Models.Model.Article> _Articles;
        public List<Models.Model.Article> Articles
        {
            get { return _Articles; }
            set { _Articles = value; RaisePropertyChanged(); }
        }

        private Article _SelectedArticles;
        public Article SelectedArticles
        {
            get { return _SelectedArticles; }
            set { _SelectedArticles = value; RaisePropertyChanged(); }
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
                IsLoading = true;
                IsPageEnabled = false;
            }
            catch (System.Exception)
            {
                //Show Dialoge 
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