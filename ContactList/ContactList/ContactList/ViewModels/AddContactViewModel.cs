using ContactList.Models;
using ContactList.Services.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactList.ViewModels
{
    public class AddContactViewModel : BaseViewModel
    {
        readonly IPersonService personService;
        readonly INavigationPageService navigationPageService;

        public AddContactViewModel(IPersonService personService, INavigationPageService navigationPageService)
        {
            this.personService = personService;
            this.navigationPageService = navigationPageService;
        }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public ICommand AddContactCommand => new Command(() => 
        {
            var contact = new Person();
            contact.FullName = FullName;
            contact.PhoneNumber = PhoneNumber;

            personService.AddPerson(contact);

            navigationPageService.NavigationPagePop();
        });
    }
}
