namespace SiteSheets
{
    class Client:Person
    {
        public Client(string first, string last, string phone, string city, string street, string email) : base(first, last, phone, city, street, email)
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