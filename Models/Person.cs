using ProjetoEduardoAnacletoWindowsForm1.Models;

namespace EHA_AspNetCore_Angular.Models
{
    public abstract class Person : Identification
    {
        public string Name { get; private set; }
        public int Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string EmailAddress { get; private set; }
        public int PhoneNumber { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public string Address { get; private set; }

        public Person(string name, int gender, DateTime dateOfBirth, string emailAddress, int phoneNumber, string country,
                string state, string city, string district, string address)
        {
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Country = country;
            State = state;
            City = city;
            District = district;
            Address = address;
        }

        public Person()
        {
            
        }
    }
}
