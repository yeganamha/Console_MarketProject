using ConsoleApp_Project.Abstract;
using ConsoleApp_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Project.Interfaces.Services
{
    public class ProductService:IProduct
    {
        public static List<Product> Products;
        public ProductService()
        {
            Products = new List<Product>();
        }
        public static List<Product> GetProducts()
        {
            return Products;    
        }
        public static int AddProduct(string name, decimal price, string category, int count)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new FormatException("Name is empty!");
            if (price < 0)
                throw new FormatException("Price is lower than 0!");
            bool isSuccessful
                = Enum.TryParse(typeof(Category), category, true, out object parsedCategory);
            if (!isSuccessful)
            {
                throw new InvalidDataException("Category not found!");
            }

            if (count < 0) 
            {
                throw new FormatException("Invalid count");
            }
            var newProduct = new Product
            {
                Name = name,                
                Category = (Category)parsedCategory,
                Price = price,
                Count =count
            };

            Products.Add(newProduct);

            return newProduct.Id;

        }
        public void UpdateProduct()
        { }
        public void DeleteProduct()
        { }
        public void ShowAllProducts()
        { }
        public void AsCategoryShowProducts()
        { }
        public void AsPriceRangeShowProducts()
        { }
        public void AsNameSearchProducts()
        { }
    }
}
