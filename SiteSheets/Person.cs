using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSheets
{
    class Person:IComparable<Person>
    {
        public string FirstName;
        public string Email;
        public string LastName;

        public string FullName { get
            {
                return FirstName + " " + LastName;
            } private set
            {
                FullName = value;
            }
        }

        public string PhoneNumber;
        public string StreetAddress;
        public string City;

        public Person(string first, string last, string phone, string city, string street, string email="undefined")
        {
            FirstName = first;
            LastName = last;
            PhoneNumber = phone;
            City = city;
            StreetAddress = street;
            Email = email;
        }

        public int CompareTo(Person other)
        {
            return LastName.CompareTo(other.LastName);
        }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
