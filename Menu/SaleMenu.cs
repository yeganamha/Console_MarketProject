using ConsoleApp_Project.Abstract;
using ConsoleApp_Project.Interfaces.Services;
using ConsoleApp_Project.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    

namespace ConsoleApp_Project.Menu
{
    public class SaleMenu
    {
        private static SaleService SaleService = new();
        private List<Sales> Sales;

        public static void AddNewSale()
        {
            try
            {
                SaleItems.ResetSaleItems();

                List<SaleItems> saleItems = new List<SaleItems>();
                bool addItems = true;

                while (addItems)
                {
                    Console.WriteLine("Enter product code:");
                    int productCode;

                    while (!int.TryParse(Console.ReadLine(), out productCode))
                    {
                        Console.WriteLine("Invalid product code! Please enter a valid integer:");
                    }

                    Console.WriteLine("Enter the quantity:");
                    int quantity;

                    while (!int.TryParse(Console.ReadLine(), out quantity))
                    {
                        Console.WriteLine("Invalid quantity! Please enter a valid integer:");
                    }

                    var product = ProductService.GetProductsiD(productCode);

                    var salesItem = new SaleItems
                    {
                        count = quantity,
                        product = product
                    };
                    saleItems.Add(salesItem);

                    Console.WriteLine("Do you want to add more items? (yes/no)");
                    string choice = Console.ReadLine();

                    if (choice.ToLower() != "yes")
                    {
                        addItems = false;
                    }

                }

                var Sale = new Sales
                {
                    Date = DateTime.Now,
                    SaleAmount = saleItems.Sum(item => item.product.Price * item.count),
                    Items = saleItems
                };

                SaleService.AddSales(Sale);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error message: " + ex.Message);
            }
        }

        public static void ShowAllSales()
        {
            SaleService.ShowAllSales();
        }

        public static void ShowSalesbyPriceRange()
        {
            Console.WriteLine("Enter min price:");
            decimal priceSales = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter max price: ");
            decimal priceSaless = decimal.Parse(Console.ReadLine());
            SaleService.DisplaySalesByPriceRange(priceSales, priceSaless);
        }

        public static void DeleteSale()
        {
            try
            {
                Console.WriteLine("Enter product ID :");
                int productId = int.Parse(Console.ReadLine());
                SaleService.DeleteSales(productId);
                Console.WriteLine($"Successfully deleted product with ID: {productId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuShowSalesByDateRange()
        {


            try
            {
                Console.WriteLine("Enter start date (MM/dd/yyyy): ");
                DateTime startDay;

                if (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDay))
                {
                    Console.WriteLine("Invalid input. Please enter valid date (MM/dd/yyyy).");
                    return;
                }

                Console.WriteLine("Enter end date (MM/dd/yyyy): ");
                DateTime endDay;

                if (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDay))
                {
                    Console.WriteLine("Invalid input. Please enter valid date (MM/dd/yyyy).");
                    return;
                }

                SaleService.ShowSalesByDateRange(startDay, endDay);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while processing. Message: {ex.Message}");
            }
                  
        }


    }
}
