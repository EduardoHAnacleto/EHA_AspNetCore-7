namespace EHA_AspNetCore_Angular.Models
{
    public class Supplier : Person
    {
        public Person Person { get; private set; }
        public string CompanyName { get; private set; }
        public int RegistrationNumber { get; private set; }
        public PaymentCondition PreferredPayCondition { get; private set; }

        public Supplier(string name, int gender, DateTime dateOfBirth, string emailAddress, int phoneNumber, string country,
                        string state, string city, string district, string address, string companyName, int registrationNumber,
                        PaymentCondition preferredPayCondition)
            : base(name, gender, dateOfBirth, emailAddress, phoneNumber, country, state, city, district, address)
        {
            CompanyName = companyName;
            RegistrationNumber = registrationNumber;
            PreferredPayCondition = preferredPayCondition;
        }

    }
}
