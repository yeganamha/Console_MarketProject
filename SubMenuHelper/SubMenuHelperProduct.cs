﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.SubMenuHelper
{
    public static class SubMenuHelperProduct
    {
        public static void ProductSubMenu()
        {
            Console.Clear();
            int option;
            do
            {
                Console.WriteLine("1. Add new product:");
                Console.WriteLine("2. Update productI");
                Console.WriteLine("3. Delete product");
                Console.WriteLine("4. Show all product");
                Console.WriteLine("5. Show all product as category");
                Console.WriteLine("6. Show all product as price range");
                Console.WriteLine("7. Search product as name");
                Console.WriteLine("0. Go back ");



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
                        
                        break;
                    case 2:
                        
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("There is no such option!");
                        break;
                }

            } while (option != 0);
        }

    }
}
 