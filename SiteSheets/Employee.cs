namespace SiteSheets
{
    class Employee:Person
    {
        public uint Wage;
            public Employee(string first, string last, string phone, string city, string street, string email, uint wage):
            base(first, last, phone, city, street)
        {
            FirstName = first;
            LastName = last;
            PhoneNumber = phone;
            City = city;
            StreetAddress = street;
            Email = email;
            Wage = wage;
        }

    }
}