using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyDapperExercise
{
    public interface IProductrepository

    {
        IEnumerable<Product> GetAllProducts();

        public void CreateProduct(string name, double price, int categoryID);
        public void UpdateProduct(int productID, double price);
        public void DeleteProduct(int productID);

        //    Create a IProductRepository Interface - this interface will have:
        //      A GetAllProducts() method:
        //      A CreateProduct(string name, double price, int categoryID) method:
       
    }
}
