using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjetoEduardoAnacletoWindowsForm1.Models
{
    public abstract class Identification 
    {

        public Guid Id { get; }
        public DateTime DateOfCreation { get; }
        public DateTime DateOfLastUpdate { get; }

    }
}
