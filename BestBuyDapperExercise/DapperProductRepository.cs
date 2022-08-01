using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyDapperExercise
{
    public class DapperProductRepository : IProductrepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products(Name, Price, CategoryID) VALUES (@productName, @productPrice, @ProductCategoryID);",
                new { productName = name, productPrice = price, productCategoryID = categoryID });
            Console.WriteLine("Product has been successfully created!");
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
                new { productID = productID });
            Console.WriteLine("Your product has been sucessfully deleted!");
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

            public void UpdateProduct(int productID, double price)
        {
            _connection.Execute("UPDATE products SET Price = @productPrice WHERE ProductID = @productID;",
                 new { productPrice = price, productID = productID });
            Console.WriteLine("Your Product has successfully udpated!");
        }
    }
}
