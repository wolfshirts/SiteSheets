namespace SiteSheets
{
    class Contractor:Person
    {
        public Contractor(string first, string last, string phone, string city, string street, string email) : base(first, last, phone, city, street, email)
        {
            FirstName = first;
            LastName = last;
            PhoneNumber = phone;
            City = city;
            StreetAddress = street;
            Email = email;
        }
    }
}