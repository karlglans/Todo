using System;
using Xunit;
using Todo.Data;
using Todo.Model;

namespace Test.Data
{
    [Collection("Serial")]
    public class PeopleTest
    {
        const string someFirstName = "someFirstName";
        const string someLastName = "someLastName";
        People people;

        public PeopleTest()
        {
            people = new People();
            people.Clear(); // to make sure static People:people is resetted befor each test
        }

        [Fact]
        public void PeopleShouldHaveSizeZero_whenFirstCreated()
        {
            Assert.Equal(0, people.Size());
        }

        [Fact]
        public void Clear_shouldLeadToSizeZero()
        {
            people.CreatePerson(someFirstName, someLastName);
            Assert.Equal(1, people.Size());
            people.Clear();
            Assert.Equal(0, people.Size());
        }

        [Fact]
        public void CreatePerson_shouldGenerateAPersonObject()
        {
            Person person = people.CreatePerson(someFirstName, someLastName);
            Assert.Equal(someFirstName, person.FirstName);
            Assert.Equal(someLastName, person.LastName);
            Assert.NotEqual(0, person.PersonId); // is given an valid id
        }

        [Fact]
        public void CreatePerson_shouldStoreTheCreatedPerson()
        {
            int sizeBefore = people.Size();
            Assert.Equal(0, sizeBefore);
            Person person = people.CreatePerson(someFirstName, someLastName);
            int sizeAfter = people.Size();
            Assert.Equal(1, sizeAfter);
            Person lastPersonInArray = people.FindAll()[0];
            Assert.Equal(person, lastPersonInArray);
        }

        [Fact]
        public void FindById_whenGivenAnExistingPersonId()
        {
            string nameForPersonTwo = "nameForPersonTwo";
            // adding 3 persons
            people.CreatePerson(someFirstName, someLastName);
            Person person2 = people.CreatePerson(nameForPersonTwo, someLastName);
            people.CreatePerson(someFirstName, someLastName);

            Person foundPerson = people.FindById(person2.PersonId);
            Assert.Equal(person2, foundPerson);
        }

        [Fact]
        public void FindById_whenGivenAnNoneExistentPersonId()
        {
            // adding 3 persons
            people.CreatePerson(someFirstName, someLastName);
            Person person2 = people.CreatePerson(someFirstName, someLastName);
            people.CreatePerson(someFirstName, someLastName);

            int nonexistentId = person2.PersonId + 10; // since we did not add more the 3 persons
            Assert.Null(people.FindById(nonexistentId));
        }

        [Fact]
        public void RemovePerson_whenGivenAnExistingTodo()
        {
            // arrange: adding 3 persons
            people.CreatePerson(someFirstName, someLastName);
            Person item2 = people.CreatePerson(someFirstName, someLastName);
            people.CreatePerson(someFirstName, someLastName);
            // act reove 2nd item
            bool wasRemoved = people.RemovePerson(item2);
            Assert.True(wasRemoved);
            Assert.Equal(2, people.Size());
        }

        [Fact]
        public void RemovePerson_whenGivenAnAlreadyRemovedTodo()
        {
            // arrange: adding 3 persons
            people.CreatePerson(someFirstName, someLastName);
            Person item2 = people.CreatePerson(someFirstName, someLastName);
            people.CreatePerson(someFirstName, someLastName);
            people.RemovePerson(item2); // remove first time
            // act: removing todo a 2nd time
            bool wasRemovedAgain = people.RemovePerson(item2); // remove second time
            Assert.False(wasRemovedAgain);
        }
    }
}
