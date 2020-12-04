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
        readonly IPageDialogService pageDialogService;

        public AddContactViewModel(IPersonService personService, INavigationPageService navigationPageService, IPageDialogService pageDialogService)
        {
            this.personService = personService;
            this.navigationPageService = navigationPageService;
            this.pageDialogService = pageDialogService;
        }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public ICommand AddContactCommand => new Command(() => 
        {
            if (string.IsNullOrEmpty(FullName))
            {
                pageDialogService.DisplayAlert("Error", "Must complete with full name");
            }
            else if (string.IsNullOrEmpty(PhoneNumber))
            {
                pageDialogService.DisplayAlert("Error", "Must complete with phone number");
            }
            else
            {

                var contact = new Person();
                contact.FullName = FullName;
                contact.PhoneNumber = PhoneNumber;

                personService.AddPerson(contact);

                navigationPageService.NavigationPagePop();
            }
            
        });
    }
}
