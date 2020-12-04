using ContactList.Models;
using ContactList.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ContactList.Services
{
    public class PersonService : IPersonService
    {
        readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "People.txt");
        public ObservableCollection<Person> GetPeopleList()
        {
            if (!File.Exists(filePath))
                File.CreateText(filePath);

            var lines = File.ReadAllLines(filePath).ToList();

            var peopleList = new ObservableCollection<Person>();

            foreach (var line in lines)
            {
                var lineArr = line.Split('|');
                var person = new Person();
                person.FullName = lineArr[0];
                person.PhoneNumber = lineArr[1];

                peopleList.Add(person);
            }

            return peopleList;
        }
        public void AddPerson(Person person)
        {
            var peopleList = GetPeopleList();
            peopleList.Add(person);

            var lines = new List<string>();

            foreach (var personx in peopleList)
            {
                lines.Add(personx.FullName + "|" + personx.PhoneNumber);
            }

            File.WriteAllLines(filePath, lines);
        }
        public void DeletePerson(Person person)
        {
            var peopleList = GetPeopleList();

            var removePerson = peopleList.FirstOrDefault(p => p.FullName == person.FullName && p.PhoneNumber == person.PhoneNumber);

            peopleList.Remove(removePerson);

            var lines = new List<string>();

            foreach (var personx in peopleList)
            {
                lines.Add(personx.FullName + "|" + personx.PhoneNumber);
            }

            File.WriteAllLines(filePath, lines);
        }

        public void EditPerson(Person originalPerson, Person editedPerson)
        {
            bool isEdited = false;

            var peopleList = GetPeopleList();

            var lines = new List<string>();

            foreach (var person in peopleList)
            {
                if(person.FullName == originalPerson.FullName && person.PhoneNumber == originalPerson.PhoneNumber)
                {
                    if (!isEdited)
                    {
                        lines.Add(editedPerson.FullName + "|" + editedPerson.PhoneNumber);
                        isEdited = true;
                    }
                    else
                        lines.Add(person.FullName + "|" + person.PhoneNumber);
                }
                else
                    lines.Add(person.FullName + "|" + person.PhoneNumber);

            }

            File.WriteAllLines(filePath, lines);
        }

    }
}
