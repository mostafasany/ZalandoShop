using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ZalandoShop.Services.Services.DialogService;

namespace ZalandoShop.Core.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public async Task ShowMessage(string message, string header = "")
        {
            MessageDialog dialog = new MessageDialog(message, header);
            await dialog.ShowAsync();
        }
    }
}
