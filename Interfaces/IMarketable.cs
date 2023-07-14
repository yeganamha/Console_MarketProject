using ConsoleApp_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.Interfaces
{
    public interface IMarketable
    {
        public List<Sales> Sales { get; set; }
        public List<Product> Products { get; set; }




        void AddSales(Sales sales)
        {
            foreach (var item in Products)
            {
                    if (sales.SaleItems.Product.Name == item.Name)
                    {

                    }
            }
        }  


        void ReturnSale(int id)
        {
            


        }



        void ReturnItemSales(int id,int ItemsId)
        {
            var wantedSale = Sales.FirstOrDefault(x => x.Id == id);
            var items = wantedSale.SaleItems.Equals(ItemsId);
            if(wantedSale!=null&& items != null)
            {
                 wantedSale.SaleItems.Id = ItemsId;
            }
        }






    }
}
