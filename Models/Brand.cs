using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEduardoAnacletoWindowsForm1.Models
{
    public class Brand : Identification
    {
        public string Name { get; private set; }
        
        public Brand(string name)
        {
            Name = name;
        }

    }
}
