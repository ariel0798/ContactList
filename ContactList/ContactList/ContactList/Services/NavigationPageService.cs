using ContactList.Services.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactList.Services
{
    public class NavigationPageService : INavigationPageService
    {
        public async Task NavigationPagePush(Page page)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(page));
        }
        public async Task NavigationPagePop()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    
    }
}
