using ConsoleApp_Project.SubMenuHelper;

namespace ConsoleApp_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;

            do
            {
                Console.WriteLine("1. Operate on products");
                Console.WriteLine("2. Operate on sales");             
                Console.WriteLine("0. Exit");
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
                        SubMenuHelperProduct.ProductSubMenu();
                        
                        break;
                    case 2:
                        SubMenuHelperSales.SaleSubMenu();
                        break;
                    case 0:
                        Console.WriteLine("Exit...");
                        break;
                    
                }

            } while (option != 0);
        }
    }
}