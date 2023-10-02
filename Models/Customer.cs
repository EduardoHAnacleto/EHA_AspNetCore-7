namespace EHA_AspNetCore_Angular.Models
{
    public class Customer : Person
    {
        public Person Person { get; private set; }
        public int Type { get; private set; }
        public PaymentCondition PreferredPayCondition { get; set; }

        public Customer(string name, int gender, DateTime dateOfBirth, string emailAddress, int phoneNumber, string country,
                        string state, string city, string district, string address, int type, PaymentCondition preferredPayCondition)
            : base(name, gender, dateOfBirth, emailAddress, phoneNumber, country, state, city, district, address)
        {
            Type = type;
            PreferredPayCondition = preferredPayCondition;
        }
    }
}
