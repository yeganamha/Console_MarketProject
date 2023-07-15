using ConsoleApp_Project.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.Models
{
    public class SaleItems:BaseEntity
    {
        private static int _count = 1;
        public SaleItems()
        {
            SaleItemNum = _count;
            _count++;
        }


        public int SaleItemNum { get; set; }
        public int Number { get; set; }
        public Product product { get; set; }
        public int count { get; set; }

        public static void ResetSaleItems()
        {
            _count = 1;
        }
    }
}
