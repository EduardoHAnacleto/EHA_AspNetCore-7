using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEduardoAnacletoWindowsForm1.Models
{
    public class Product : Identification
    {
        public string Name { get; private set; }
        public decimal Value { get; private set; }
        public int Stock { get; private set; }
        public string Barcode { get; private set; }
        public string UND { get; private set; }
        public Brand Brand { get; private set; }
        public Category Category { get; private set; }

        public Product(string name, decimal value, int stock, string barcode, string und, Brand brand, Category category)
        {
            Name = name;   
            Value = value;
            Stock = stock;
            Barcode = barcode;
            UND = und;
            Brand = brand;
            Category = category;
        }
    }
}
