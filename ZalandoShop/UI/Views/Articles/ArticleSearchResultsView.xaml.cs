using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ZalandoShop.Models.Model;
using ZalandoShop.ViewModels.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZalandoShop.UI.Views.Articles
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArticleSearchResultsView : Page
    {
        ArticleSearchResultsViewModel vm;
        public ArticleSearchResultsView()
        {
            this.InitializeComponent();
            vm = this.DataContext as ArticleSearchResultsViewModel;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            vm.OnIntializeCommand.Execute(e.Parameter as FacetSearch);
        }
    }
}
