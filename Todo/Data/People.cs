using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Todo.Model;

namespace Todo.Data
{
    public class People
    {
        private static Person[] people = new Person[0];

        public int Size()
        {
            return people.Length;
        }

        public Person[] FindAll()
        {
            return people;
        }

        public Person FindById(int personId)
        {
            // TODO: add binary search tree since personId is increasing in array 
            foreach (Person person in people)
            {
                if (person.PersonId == personId) return person;
            }
            return null;
        }

        private void AddPersonToPeople(Person person)
        {
            int lastSize = people.Length;
            Array.Resize(ref people, lastSize + 1);
            people[lastSize] = person; // will put the person in the last position
        }

        public Person CreatePerson(string firstName, string lastName)
        {
            int personId = PersonSequencer.NextPersonId();
            Person person = new Person(personId);
            person.FirstName = firstName;
            person.LastName = lastName;
            AddPersonToPeople(person);
            return person;
        }

        public void Clear()
        {
            Array.Resize<Person>(ref People.people, 0);
        }

        public bool RemovePerson(Person person)
        {
            Person found = FindById(person.PersonId);
            people = people.Where(val => val.PersonId != person.PersonId).ToArray();
            return found != null;
        }
    }
}
