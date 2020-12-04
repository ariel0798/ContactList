using ContactList.Models;
using ContactList.Services.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactList.ViewModels
{
    public class EditContactViewModel: BaseViewModel
    {
        public EditContactViewModel(Person person, IPersonService personService, INavigationPageService navigationPageService, IPageDialogService pageDialogService)
        {
            this.person = person;

            FullName = person.FullName;
            PhoneNumber = person.PhoneNumber;

            this.personService = personService;
            this.navigationPageService = navigationPageService;
            this.pageDialogService = pageDialogService;
        }

        readonly Person person;
        readonly IPersonService personService;
        readonly INavigationPageService navigationPageService;
        readonly IPageDialogService pageDialogService;

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public ICommand EditContactCommand => new Command(() => 
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
                var editedPerson = new Person()
                { FullName = this.FullName, PhoneNumber = this.PhoneNumber };

                personService.EditPerson(person, editedPerson);

                navigationPageService.NavigationPagePop();
            }
        });
    }
}
