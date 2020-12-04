using ContactList.ViewModels;
using ContactList.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContactPage : ContentPage
    {
        public AddContactPage()
        {
            InitializeComponent();
            this.BindingContext = new AddContactViewModel(new PersonService(), new NavigationPageService());
        }
    }
}