using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Category Categories { get; set; }  
    }

    public enum Category
    { 
        Water,
        Fruit,
        Vegetable,
        Seafood,
        cookies,
        gastronomy

    }
}
