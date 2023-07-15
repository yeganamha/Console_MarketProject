using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.Abstract
{
    public interface ISale
    {
        public void AddSale();
        public void ReturnSale();
        public void DeleteSale();
        public void ShowAllSales();
        public void AsDateRangeShowSales();
        public void AsPriceRangeShowSales();
        public void AsPriceShowSales();
        public void AsIdShowSaleInformation();

    }
}
