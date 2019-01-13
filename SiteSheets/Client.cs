namespace SiteSheets
{
    class Client:Person
    {
        public Client(string first, string last, string phone, string city, string street) : base(first, last, phone, city, street)
        {
            FirstName = first;
            LastName = last;
            PhoneNumber = phone;
            City = city;
            StreetAddress = street;
        }
    }
}