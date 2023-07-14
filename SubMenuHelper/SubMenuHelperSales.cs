using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.SubMenuHelper
{
    public static class SubMenuHelperSales
    {
        public static void SaleSubMenu()
        {
            Console.Clear();
            int option;
            do
            {
                Console.WriteLine("1. Add new sale:");
                Console.WriteLine("2. Return product from sale");
                Console.WriteLine("3. Delete sale");
                Console.WriteLine("4. Show all sales");
                Console.WriteLine("5. Show sales as date range:");
                Console.WriteLine("6. Show sales as price range");
                Console.WriteLine("7. Show sales as date ");
                Console.WriteLine("0. Show sale as Id: ");



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
}
