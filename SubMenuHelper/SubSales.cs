﻿using ConsoleApp_Project.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.SubMenuHelper
{
    public class SubSales
    {
            public static void SaleSubMenu()
            {
                Console.Clear();
                int option;
                do
                {
                    Console.WriteLine("1. Add new sale:");//+
                    Console.WriteLine("2. Return product from sale");
                    Console.WriteLine("3. Delete sale");//+
                    Console.WriteLine("4. Show all sales");//+
                    Console.WriteLine("5. Show sales as date range:");//+
                    Console.WriteLine("6. Show sales as price range");//+
                    Console.WriteLine("7. Show sales as date ");
                    Console.WriteLine("8. Show sale as Id: ");



                    Console.WriteLine("-----------");
                    Console.WriteLine("Enter option:");

                    while (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid number!");
                        Console.WriteLine("-----------");
                        Console.WriteLine("Enter option:");
                    }

                    switch (option)
                    {
                        case 1:
                            SaleMenu.AddNewSale();
                            break;
                        case 2:
                       
                            break;
                        case 3:
                        SaleMenu.DeleteSale();
                            break;
                        case 4:
                        SaleMenu.ShowAllSales();
                            break;
                        case 5:
                        SaleMenu.MenuShowSalesByDateRange();
                            break;
                        case 6:
                        SaleMenu.ShowSalesbyPriceRange();
                            break;
                        case 7:
                        SaleMenu.MenuShowSaleByID();    
                        break;
                        default:
                            Console.WriteLine("There is no such option!");
                            break;
                    }

                } while (option != 0);
            }

        }
    }

