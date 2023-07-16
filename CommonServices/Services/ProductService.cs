using ConsoleTables;
using ConsoleApp_Project.Abstract;
using ConsoleApp_Project.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp_Project.Interfaces.Services
{
    public class ProductService : IProduct
    {
        public static List<Product> Products = new List<Product>();
        public ProductService()
        {
            Products = new List<Product>();
        }
        public static List<Product> GetProducts()
        {
            return Products;
        }
        public static Product GetProductsiD(int code)
        {
            return Products.FirstOrDefault(x => x.Id == code);
        }
        public static int AddProduct(string name, decimal price, string category, int count)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new FormatException("Name is empty!");
            if (price < 0)
                throw new FormatException("Price is lower than 0!");
            bool isSuccessful = Enum.TryParse(typeof(Category), category, true, out object parsedCategory);
            if (!isSuccessful)
                throw new InvalidDataException("Category not found!");
            if (count < 0)
                throw new FormatException("Invalid count");
            var newProduct = new Product
            {
                Name = name,
                Category = (Category)parsedCategory,
                Price = price,
                Count = count
            };

            Products.Add(newProduct);

            return newProduct.Id;

        }
        public static void UpdateProduct(int id, string name, int count, object category, decimal price)
        {
            Product UpdateProduct = Products.FirstOrDefault(x => x.Id == id);
            if (UpdateProduct == null)
                throw new Exception($"{id} is invalid");
            if (price < 0)
                throw new FormatException("Price is lower than 0!");
            if (count < 0)
                throw new FormatException("Invalid count!");
            UpdateProduct.Name = name;
            UpdateProduct.Price = price;
            UpdateProduct.Count = count;
        }
        public static void DeleteProduct(int id)
        {
            var ExistingProduct = Products.FirstOrDefault(x => x.Id == id);
            if (ExistingProduct == null)
                throw new Exception($"Product with ID {id} not found");
            Products = Products.Where(x => x.Id != id).ToList();
        }
        public static void ShowAllProducts()
        {
            try
            {
                var products = GetProducts();
                var table = new ConsoleTable("ID", "Name", "Count", "Price", "Category");
                if (products.Count == default)
                {
                    Console.WriteLine("There is no product");
                    return;
                }
                foreach (var product in products)
                {
                    table.AddRow(product.Id, product.Name, product.Count, product.Price,
                         product.Category);
                }
                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
        

        public static void AsPriceRangeShowProducts(decimal minPrice, decimal maxPrice)
        {
            // Filter sales within the given price range
            var range = Products.FindAll(x => x.Price >= minPrice && x.Price <= maxPrice);

            var products = GetProducts();
            var table = new ConsoleTable("ID", "Name", "Count", "Price", "Category");
            if (range.Count == 0)
            {
                Console.WriteLine("NO PRODUCT YET");
                return;
            }
            foreach (var product in range)
            {
                table.AddRow(product.Id, product.Name, product.Count, product.Price,
                     product.Category);
            }
            table.Write();
            return;
        }
        public static void  SearchProductsByName(string productName)
        {
            var searchProductByName = Products.Where(x => x.Name.ToLower() == productName.ToLower()).ToList();

            var tableForName = new ConsoleTable("Code", "Product Name", "Product Quantity",
                    "Product Price", "Category");

            if (searchProductByName.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (var product in searchProductByName)
            {
                tableForName.AddRow(product.Id, product.Name, product.Count, product.Price, product.Category);
            }

            tableForName.Write();


            
        }

        public static void ShowAllCategory(object productCategory)
        {
            foreach (var item in Enum.GetNames(typeof(Category)))
            {
                Console.WriteLine(item);
            }

            if (!Enum.IsDefined(typeof(Category), productCategory))
            {
                Console.WriteLine("Invalid category number!");

                return;

            }

        }

        public static void EnumList()
        {
            foreach (var item in Enum.GetNames(typeof(Category)))
            {
                Console.WriteLine(item);
            }
        }

        public void AsCategoryShowProducts(Category category)
        {
            var showByCategory = Products.FindAll(x => x.Category.ToString().ToLower() == category.ToString().ToLower()).ToList();
            var tableForCategory = new ConsoleTable("Code", "Product Name", "Product Quantity",
                   "Product Price", "Category");
            if (showByCategory.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (var product in showByCategory)
            {
                tableForCategory.AddRow(product.Id, product.Name, product.Count, product.Price, product.Category.ToString());
            }

            tableForCategory.Write();
        }

        internal static void SearchProductsByName(Category searchCategory)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByCode(int productCode)
        {
            var product = Products.SingleOrDefault(x => x.Id == productCode);

            if (product == null)
            {
                throw new Exception("Product not found.!");
            }

            return product;
        }
    }
}