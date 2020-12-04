using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactList.Services.Interfaces
{
    public interface INavigationPageService
    {
        Task NavigationPagePush(Page page);
        Task NavigationPagePop();
    }
}
