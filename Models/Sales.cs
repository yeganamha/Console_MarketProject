using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.Models
{
    public class Sales:BaseEntity
    {
        private static int _count = 1;
        public Sales()
        {
            Id = _count;
            _count++;
        }  
        public decimal SaleAmount { get; set; }
        public List<SaleItems> Items { get; set; }
        public DateTime Date { get; set; }


    }
}
