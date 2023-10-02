using ProjetoEduardoAnacletoWindowsForm1.Models;

namespace EHA_AspNetCore_Angular.Models
{
    public class Instalment : Identification
    {
        public int Number { get; private set; }
        public int Days { get; private set; }
        public decimal Percentage { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        public Instalment(int number, int days, decimal percentage, PaymentMethod paymentMethod)
        {
            Number = number;
            Days = days;
            Percentage = percentage;
            PaymentMethod = paymentMethod;
        }
    }
}
