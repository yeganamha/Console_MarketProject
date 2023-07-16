using ConsoleApp_Project.Abstract;
using ConsoleApp_Project.Models;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.Interfaces.Services
{
    public class SaleService
    {
        public static List<Sales> Sales;
        public SaleService()
        {
            Sales = new List<Sales>();
        }
        public static List<Sales> GetSales()

        {
            return Sales;
        }

        public static void AddSales(Sales sale)
        {
            try
            {
                if (sale.Items == null || sale.Items.Count == 0)
                {
                    Console.WriteLine("No sale items found.");
                    return;
                }

                foreach (var saleItem in sale.Items)
                {
                    if (saleItem.product.Id < 0)
                        throw new FormatException("Product Code is lower than 0.");


                    var findProductToAdd = ProductService.GetProductsiD(saleItem.product.Id);

                    if (findProductToAdd == null)
                    {
                        Console.WriteLine("No products found.");
                        return;
                    }

                    if (findProductToAdd.Count < saleItem.count)
                    {
                        Console.WriteLine("Insufficient quantity available! The quantity you are asking for is more than available in the market!");
                        return;
                    }

                    findProductToAdd.Count -= saleItem.count;
                }

                Sales.Add(sale);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops! Got an error!{ex.Message}");
            }

        }

        public static void ShowAllSales()
        {
            try
            {
                var sales = GetSales();

                var table = new ConsoleTable("Sales", "SalesItem", "Count", "Product Name", "Price", "DateTime");
                if (sales.Count == 0)
                {
                    Console.WriteLine("There is no product");
                    return;
                }
                foreach (var sale in sales)
                {
                    if (sale.Items != null && sale.Items.Count > 0)
                    {
                        foreach (var saleitem in sale.Items)
                        {
                            var productName = saleitem.product != null ? saleitem.product.Name : string.Empty;

                            table.AddRow(sale.Id, saleitem.SaleItemNum, saleitem.count, productName, sale.SaleAmount, sale.Date);
                        }
                    }
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");

                Console.WriteLine(ex.Message);
            }

        }
        public static void DisplaySalesByPriceRange(decimal minSalesPrice, decimal maxSalesPrice)
        {
            var range = Sales.Where(x => x.SaleAmount >= minSalesPrice && x.SaleAmount <= maxSalesPrice).ToList();

            var sales = GetSales();

            var table = new ConsoleTable("Sales", "SalesItem", "Count", "Product Name", "Total Price", "DateTime");

            if (range.Count == 0)
            {
                Console.WriteLine("There is no product");
                return;
            }
            foreach (var sale in range)
            {
                if (sale.Items != null && sale.Items.Count > 0)
                {
                    foreach (var saleitem in sale.Items)
                    {
                        var productName = saleitem.product != null ? saleitem.product.Name : string.Empty;

                        table.AddRow(sale.Id, saleitem.SaleItemNum, saleitem.count, productName, sale.SaleAmount, sale.Date);
                    }
                }
            }

            table.Write();
            return;
        }

        public static void DeleteSales(int code)
        {
            var existingProduct = Sales.Find(x => x.Id == code);

            if (existingProduct == null)

            throw new Exception($"Product with ID {code} not found");

            Sales = Sales.Where(x => x.Id != code).ToList();
        }

        public void ShowSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddDays(1).AddSeconds(-1);


            if (startDate > endDate)
                throw new InvalidDataException("Start date cannot be greater than end date!");

            if (endDate.Date > DateTime.Now.AddDays(1))
            {
                throw new InvalidDataException("End date cannot be greater than today's day!");
            }

            var showByDate = Sales.FindAll(x => x.Date >= startDate && x.Date <= endDate).ToList();

            var table = new ConsoleTable("Sale Number", "SaleItem Number", "Quantity", "Product Name", "Amount", "Date");
            if (showByDate.Count > 0)
            {
                foreach (var sale in showByDate)
                {
                    foreach (var access in sale.Items)
                    {
                        table.AddRow(sale.Id, access.SaleItemNum, access.count, access.product.Name, sale.SaleAmount, sale.Date);
                    }


                }
                table.Write(Format.Alternative);
            }
            else
            {
                throw new Exception("No sales found within the given date range.");
            }

        }

        public void ShowSalesByDate(DateTime date)
        {
            Console.WriteLine(date);

            if (date > DateTime.Now.AddSeconds(-1))
            {
                throw new InvalidDataException("Exceeded Today's Date... End date cannot be greater than today's day!");
            }

            var showByDate = Sales.FindAll(x => x.Date.AddSeconds(-1) >= date || x.Date.AddSeconds(1) <= date).ToList();


            var table = new ConsoleTable("Sale Number", "SaleItem Number", "Quantity", "Product Name", "Sale Amount", " Sale Date");
            if (showByDate.Count > 0)
            {
                foreach (var saleD in showByDate)
                {
                    foreach (var access in saleD.Items)
                    {
                        table.AddRow(saleD.Id, access.SaleItemNum, access.count, access.product.Name, saleD.SaleAmount, saleD.Date);
                    }


                }
                table.Write(Format.Alternative);
            }
            else
            {
                throw new Exception("No sales found within the given date .");
            }
        }



        private object GetProductByCode(int id)
        {
            throw new NotImplementedException();
        }

        public void ShowSaleById(int saleNumber)
        {
            if (saleNumber < 0) 
            {
                throw new FormatException("Sale Number is lower than 0.");
            }

            var saleRes = Sales.SingleOrDefault(x => x.Id == saleNumber);

            if (saleRes == null)
            {
                throw new Exception("Product not found. xexe");
            }
            var table = new ConsoleTable("Sale Number", "SaleItem Number", "Quantity", "Product Name", "Amount", "Date");
            foreach (var item in saleRes.Items)
            {
                table.AddRow(saleRes.Id, item.SaleItemNum, item.count, item.product.Name, saleRes.SaleAmount, saleRes.Date);
            }

            table.Write(Format.Alternative);

        }

    }


}

