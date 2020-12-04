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
        public ContactsViewModel(INavigationPageService navigationPageService, IPersonService personService, IPageDialogService pageDialogService)
        {
            this.navigationPageService = navigationPageService;
            this.personService = personService;
            this.pageDialogService = pageDialogService;

            Refresh();
        }

        readonly INavigationPageService navigationPageService;
        readonly IPersonService personService;
        readonly IPageDialogService pageDialogService;

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

        public bool IsRefreshing { get; set; }
        public bool IsEmptyData { get; set; }
        

        public ICommand AddContactCommand => new Command(async() =>
        {
            await navigationPageService.NavigationPagePush(new AddContactPage());
            Refresh();
        });

        public ICommand DeleteContactCommand => new Command<Person>((person) =>
        {
            personService.DeletePerson(person);
            Refresh();
        });

        public ICommand MoreOptionsCommand => new Command<Person>(async (person) =>
        {
            string call = "Call " + person.PhoneNumber, edit = "Edit";
            string action = await pageDialogService.DisplayActionSheet(call, edit);
            if(action == call)
            {
                PhoneDialer.Open(person.PhoneNumber);
            }
            else if(action == edit)
            {
                await navigationPageService.NavigationPagePush(new EditContactPage(person));
                Refresh();
            }
        });
        public ICommand RefreshCommand => 
            new Command(() => Refresh());

        public void Refresh()
        {
            IsRefreshing = true;
            ContactsList = personService.GetPeopleList();

            if (ContactsList.Count == 0)
                IsEmptyData = true;
            else
                IsEmptyData = false;

            IsRefreshing = false;
        }

        public async Task ContactInformation(Person person)
        {
            await navigationPageService.NavigationPagePush(new ContactInformationPage(person));
        }
    }
}
