using ConsoleApp_Project.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.SubMenuHelper
{
    public static class SubProduct
    {
        public static void ProductSubMenu()
        {
            
            int option;
            do
            {
                Console.WriteLine("1. Add new product:");//+
                Console.WriteLine("2. Update productI");//+
                Console.WriteLine("3. Delete product");//+
                Console.WriteLine("4. Show all product");//+
                Console.WriteLine("5. Show all product as category"); //+
                Console.WriteLine("6. Show all product as price range");//+
                Console.WriteLine("7. Search product as name");//+
               


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
                        ProductMenu.AddProduct();
                        break;
                    case 2:
                        ProductMenu.UpdateProduct();
                        break;
                    case 3:
                        ProductMenu.DeleteProduct();
                        break;
                        case 4:
                        ProductMenu.ShowAllProduct();
                            break;
                        case 5:
                        ProductMenu.MenuShowProductsByCategory();
                            break;
                        case 6:
                        ProductMenu.ShowProductPricebyRange();
                            break;
                        case 7:
                        ProductMenu.MenuSearchProductsByName();
                            break;

                        default:
                        Console.WriteLine("There is no such option!");
                        break;
                }

            } while (option != 0);
        }

    }
}
 