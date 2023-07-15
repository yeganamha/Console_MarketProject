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
    public class ProductService:IProduct
    {   
        public static List<Product> Products =new List<Product>();
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
                Count =count
            };

            Products.Add(newProduct);

            return newProduct.Id;

        }
        public static void UpdateProduct(int id, string name,int count , object category, decimal price)
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
        public static void EnumList()
        {
            foreach (var item in Enum.GetNames(typeof(Category)))
            {
                Console.WriteLine(item);
            }
        }
    }
}
