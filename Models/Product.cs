using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp_Project.Interfaces;
using ConsoleApp_Project.Models;

namespace ConsoleApp_Project.Models
{
    public class Product:BaseEntity
    {
        private static int _counter;
        

        public Product()
        {
            _counter++;
            Id = _counter;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int Count { get; set; }  
    }

   
}
