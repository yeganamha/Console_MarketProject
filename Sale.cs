using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project
{
    public class Sale
    {   
        public int Id { get; set; }    
        public decimal  SaleAmount { get; set; }    
        public SaleItem SaleItems { get; set; } 
        public DateTime Date { get; set; }  

        
    }
}
