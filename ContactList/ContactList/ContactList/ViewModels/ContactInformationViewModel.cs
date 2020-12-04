using ContactList.Models;

namespace ContactList.ViewModels
{
    public class ContactInformationViewModel: BaseViewModel
    {
        public ContactInformationViewModel(Person person)
        {
            FullName = person.FullName;
            PhoneNumber = person.PhoneNumber;
        }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
