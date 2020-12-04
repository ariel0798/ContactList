using System.Threading.Tasks;

namespace ContactList.Services.Interfaces
{
    public interface IPageDialogService
    {
        Task<string> DisplayActionSheet(string call, string edit);
        Task DisplayAlert(string title, string message, string okText = "Ok");
    }
}
