using ContactList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContactList.Services;

namespace ContactList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
            this.BindingContext = new ContactsViewModel(new NavigationPageService(), new PersonService(), new PageDialogService());
        }
    }
}