using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.Models
{
    public class SaleItem:BaseEntity
    {
        public SaleItem()
        {
            
        }   
        public Product Product { get; set; }
        public int ItemCount { get; set; }
    }
}
