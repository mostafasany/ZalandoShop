using System.Threading.Tasks;

namespace ZalandoShop.Services.Services.DialogService
{
    public interface IDialogService
    {
        Task ShowMessage(string message, string header = "");
    }
}
