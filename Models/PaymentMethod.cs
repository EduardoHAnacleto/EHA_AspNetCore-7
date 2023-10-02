using ProjetoEduardoAnacletoWindowsForm1.Models;

namespace EHA_AspNetCore_Angular.Models
{
    public class PaymentMethod : Identification
    {
        public string Name { get; private set; }

        public PaymentMethod(string name)
        {
            Name = name;
        }
    }
}
