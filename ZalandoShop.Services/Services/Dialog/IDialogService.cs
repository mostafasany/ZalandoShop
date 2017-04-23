using System.Threading.Tasks;

namespace ZalandoShop.Services.Services.Dialog
{
    public interface IDialogService
    {
        Task ShowMessage(string message, string header = "");
    }
}
