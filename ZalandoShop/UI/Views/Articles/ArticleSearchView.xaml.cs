using Windows.UI.Xaml.Controls;
using ZalandoShop.ViewModels.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZalandoShop.UI.Views.Articles
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArticleSearchView : Page
    {
        ArticleSearchViewModel vm;
        public ArticleSearchView()
        {
            this.InitializeComponent();
            vm = this.DataContext as ArticleSearchViewModel;
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                vm.FilterText = sender.Text;
                sender.ItemsSource = vm.FilteredFacets;
            }
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem is Models.Model.Facet)
                vm.OnFacetSelectedCommand.Execute(args.SelectedItem as Models.Model.Facet);
        }
    }
}
