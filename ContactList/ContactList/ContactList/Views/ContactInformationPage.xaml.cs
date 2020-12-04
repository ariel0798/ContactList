using ContactList.Models;
using ContactList.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactInformationPage : ContentPage
    {
        public ContactInformationPage(Person person)
        {
            InitializeComponent();
            this.BindingContext = new ContactInformationViewModel(person);
        }
    }
}