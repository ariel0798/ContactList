using ContactList.Models;
using System.Collections.ObjectModel;

namespace ContactList.Services.Interfaces
{
    public interface IPersonService
    {
        ObservableCollection<Person> GetPeopleList();
        void AddPerson(Person person);
        void DeletePerson(Person person);
        void EditPerson(Person originalPerson, Person editedPerson);
    }
}
