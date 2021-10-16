using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Model
{
	public class Person
	{
		private readonly int personId;
		private string firstName;
		private string lastName;

		public Person(int personId)
		{
			this.personId = personId;
		}

		public int PersonId
		{
			get { return personId; }
		}

		public string FirstName
		{
			get { return firstName; }
			set
			{
				if (!String.IsNullOrEmpty(value)) firstName = value;
				else throw new ArgumentException("missing first name");
			}
		}

		public string LastName
		{
			get { return lastName; }
			set
			{
				if (!String.IsNullOrEmpty(value)) lastName = value;
				else throw new ArgumentException("missing last name");
			}
		}
	}

}
