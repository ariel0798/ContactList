using ContactList.Models;
using ContactList.Services.Interfaces;
using ContactList.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactList.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        public ContactsViewModel(INavigationPageService navigationPageService, IPersonService personService)
        {
            this.navigationPageService = navigationPageService;
            this.personService = personService;

            ContactsList = new ObservableCollection<Person>();
            ContactsList = personService.GetPeopleList();
            //ContactsList = new List<Person>() { 
            //    new Person{FullName= "Richard Cruz", PhoneNumber="809-901-5351"},
            //    new Person{FullName= "Yeanny Castillo", PhoneNumber="809-797-5889"}

            //};
        }

        readonly INavigationPageService navigationPageService;
        readonly IPersonService personService;

        Person selectedPerson;

        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                if(value != null)
                {
                    selectedPerson = value;
                    ContactInformation(selectedPerson);
                }
            }

        }


        public ObservableCollection<Person> ContactsList { get; set; }

        public ICommand AddContactCommand => new Command(() =>
        {
            navigationPageService.NavigationPagePush(new AddContactPage());
        });

        public ICommand DeleteContactCommand => new Command<Person>((person) =>
        {
            personService.DeletePerson(person);
        });

        public ICommand EditContactCommand => new Command<Person>((person) =>
        {
            navigationPageService.NavigationPagePush(new EditContactPage(person));
        });

        public ICommand CallNumberCommand => new Command<Person>((person) =>
        {
            PhoneDialer.Open(person.PhoneNumber);
        });

        public async Task ContactInformation(Person person)
        {
            await navigationPageService.NavigationPagePush(new ContactInformationPage(person));

        }


    }
}
