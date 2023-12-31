﻿using ConsoleApp_Project.Abstract;
using ConsoleApp_Project.Interfaces.Services;
using ConsoleApp_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp_Project.Menu
{
    public class ProductMenu : IProduct
    {
        private static ProductService productservice = new ProductService();

        public static void AddProduct()
        {
            try
            {
                ProductService.EnumList();
                Console.WriteLine("Enter your category");

                Console.WriteLine("----------------");
                string category = Console.ReadLine().Trim().ToLower();


                        bool IsSuccessful = Enum.TryParse(typeof(Category), category, true,
                        out object parsedCategory);
                if (!IsSuccessful)
                {
                    throw new InvalidDataException("not found");
                }

                Console.WriteLine("----------------");

                Console.WriteLine("Enter Product name:");
                string name = Console.ReadLine();
                Console.WriteLine("----------------");

                Console.WriteLine("Enter product price");
                string price = Console.ReadLine();
                decimal currentPrice= Convert.ToDecimal(price);    

                Console.WriteLine("----------------");


                Console.WriteLine("Enter product count");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("----------------");

                int iD = ProductService.AddProduct(name, currentPrice, category, count);

                Console.WriteLine($"Successfully added product with code {iD}");

                //ProductService.ShowAllProducts();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Got an error! {ex.Message}");
            }
        }

        public static void UpdateProduct()
        {
            try
            {

                Console.WriteLine("Enter the code:");
                int code = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new name:");
                string newName = Console.ReadLine();

                Console.WriteLine("Enter the new quantity:");
                int newCount = int.Parse(Console.ReadLine());

                Console.WriteLine("Available categories:");
                foreach (Category category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine($"{(int)category}. {category}");
                }
                Console.WriteLine("Enter the category (number) of the new product:");
                int categoryNumber = int.Parse(Console.ReadLine());

                if (!Enum.IsDefined(typeof(Category), categoryNumber))
                {
                    Console.WriteLine("Invalid category number!");
                    return;
                }
                Category newCategory = (Category)categoryNumber;

                Console.WriteLine("Enter the new price:");
                decimal newPrice = decimal.Parse(Console.ReadLine());
                ProductService.UpdateProduct(code, newName, newCount, categoryNumber, newPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while processing.Error message : {ex.Message} ");

            }
        }

        public static void DeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter product ID :");
                int productId = int.Parse(Console.ReadLine());
                ProductService.DeleteProduct(productId);
                Console.WriteLine($"Successfully deleted product with ID: {productId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowAllProduct()
        {
            ProductService.ShowAllProducts();
        }

        public static void ShowProductPricebyRange()
        {
            Console.WriteLine("Enter min price");

            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter max price ");
            decimal price1 = decimal.Parse(Console.ReadLine());
            ProductService.AsPriceRangeShowProducts(price, price1);
        }

        public static void MenuSearchProductsByName()
        {
            try
            {
                Console.WriteLine("Enter Products name: ");
                string name = Console.ReadLine();
                ProductService.SearchProductsByName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void MenuShowProductsByCategory()
        {
            try
            {
                Console.WriteLine("Enter category of the product: ");
                string categoryString = Console.ReadLine();
                var searchCategory = (Category)Enum.Parse(typeof(Category), categoryString, ignoreCase: true);

                ProductService.SearchProductsByName(searchCategory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Category not found.");
            }
        }

    }    
    
}
