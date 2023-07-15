using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.Models
{
    public class Sales:BaseEntity
    {
        public Sales()
        {

        }  
        public decimal SaleAmount { get; set; }
        public SaleItem SaleItems { get; set; }
        public DateTime Date { get; set; }


    }
}
