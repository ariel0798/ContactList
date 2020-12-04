using ContactList.Models;
using ContactList.Services;
using ContactList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactPage : ContentPage
    {
        public EditContactPage(Person person)
        {
            InitializeComponent();
            this.BindingContext = new EditContactViewModel(person, new PersonService(), new NavigationPageService());
        }
    }
}