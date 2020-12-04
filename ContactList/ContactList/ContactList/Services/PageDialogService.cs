using ContactList.Services.Interfaces;
using System.Threading.Tasks;

namespace ContactList.Services
{
    public class PageDialogService : IPageDialogService
    {
        public async Task<string> DisplayActionSheet(string call, string edit)
        {
            string action = await App.Current.MainPage.DisplayActionSheet("", "Cancel", null, call, edit);

            return action;
        }
    }
}
