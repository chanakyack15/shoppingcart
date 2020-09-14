using System.Collections.Generic;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data
{
    public interface IRepo
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductId(int id);
        IEnumerable<Product> GetProductsByCategory(string category);

        

/*        bool SaveChanges();*/
    }
}