using System;
using Xunit;
using Todo.Model;

namespace Test.Model
{
    public class PersonTest
    {
        private int someSerial = 1;
        private string someValidName = "someValidName";
        private Person person;

        public PersonTest()
        {
            person = new Person(someSerial);
            Assert.NotNull(person);
        }

        [Fact]
        public void CanMakeObject()
        {
            Person person = new Person(someSerial);
            Assert.NotNull(person);
        }

        [Fact]
        public void SetFirstName_canSetAValidFirstName()
        {
            person.FirstName = someValidName;
            Assert.Equal(someValidName, person.FirstName);
        }

        [Fact]
        public void SetFirstName_willNotAllowEmpyString()
        {
            Assert.Throws<ArgumentException>(() => person.FirstName = string.Empty);
        }

        [Fact]
        public void SetFirstName_willNotAllowNull()
        {
            Assert.Throws<ArgumentException>(() => person.FirstName = null);
        }

        [Fact]
        public void SetLastName_canSetAValidFirstName()
        {
            person.LastName = someValidName;
            Assert.Equal(someValidName, person.LastName);
        }

        [Fact]
        public void SetLastName_willNotAllowEmpyString()
        {
            Assert.Throws<ArgumentException>(() => person.LastName = string.Empty);
        }

        [Fact]
        public void SetLastName_willNotAllowNull()
        {
            Assert.Throws<ArgumentException>(() => person.LastName = null);
        }
    }
}
