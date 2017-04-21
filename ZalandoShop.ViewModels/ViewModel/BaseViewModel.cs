using GalaSoft.MvvmLight;

namespace ZalandoShop.ViewModels.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        private bool _IsLoading;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set { _IsLoading = value; RaisePropertyChanged(); }
        }

        private bool _IsPageEnabled;
        public bool IsPageEnabled
        {
            get { return _IsPageEnabled; }
            set { _IsPageEnabled = value; RaisePropertyChanged(); }
        }

    }
}
