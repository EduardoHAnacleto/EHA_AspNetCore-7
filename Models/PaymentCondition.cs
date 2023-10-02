using ProjetoEduardoAnacletoWindowsForm1.Models;

namespace EHA_AspNetCore_Angular.Models
{
    public class PaymentCondition : Identification
    {
        public string Name { get; private set; }
        public List<Instalment> InstalmentList { get; private set; }

        public PaymentCondition(string name, List<Instalment> instalmentList)
        {
            Name = name;
            InstalmentList = instalmentList;
        }
    }
}
