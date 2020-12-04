using ContactList.Models;
using ContactList.Services.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactList.ViewModels
{
    public class EditContactViewModel: BaseViewModel
    {
        public EditContactViewModel(Person person, IPersonService personService, INavigationPageService navigationPageService)
        {
            this.person = person;
            FullName = person.FullName;
            PhoneNumber = person.PhoneNumber;
            this.personService = personService;
            this.navigationPageService = navigationPageService;
        }

        readonly Person person;
        readonly IPersonService personService;
        readonly INavigationPageService navigationPageService;

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public ICommand EditContactCommand => new Command(() => 
        {
            var editedPerson = new Person()
            { FullName = this.FullName, PhoneNumber = this.PhoneNumber };

            personService.EditPerson(person, editedPerson);

            navigationPageService.NavigationPagePop();
        });
    }
}
