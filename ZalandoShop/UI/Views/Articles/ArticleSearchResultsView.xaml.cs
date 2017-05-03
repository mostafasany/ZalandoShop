using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ZalandoShop.Models.Model;
using ZalandoShop.UI.Helpers;
using ZalandoShop.ViewModels.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZalandoShop.UI.Views.Articles
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArticleSearchResultsView : Page
    {
        double maxVerticalOffset = 0;
        ArticleSearchResultsViewModel vm;

        public ArticleSearchResultsView()
        {
            this.InitializeComponent();
            vm = this.DataContext as ArticleSearchResultsViewModel;
            Loaded += OnLoaded;
            this.CacheMode.
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            var scrollViewer = UIHelpers.GetChildrenOfType<ScrollViewer>(grdViewArticles).First();
            scrollViewer.ViewChanged += scrollViewer_ViewChanged;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            vm.OnIntializeCommand.Execute(e.Parameter as FacetSearch);
        }

        private void scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer sv = sender as ScrollViewer;
            var verticalOffset = sv.VerticalOffset;
            maxVerticalOffset = sv.ScrollableHeight;

            if (maxVerticalOffset < 0 || verticalOffset == maxVerticalOffset)
            {
                vm.OnLoadMoreCommand.Execute(null);
            }
        }
    }
}
