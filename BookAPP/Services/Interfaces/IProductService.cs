using BookAPP.DataDB;
using BookAPP.Models;

namespace BookAPP.Services.Interfaces
{
    public interface IProductService
    {
        //in der interface stehen nur die methoden ohne rumpf, also ohne {}
        List<Product> GetAll();
        Task<Product> CreateProduct(ProductModel model);

        public Product ReadProduct(int id);
        //Task<Product> ReadProduct(string Name, string Category, double Price); wäre auch richtig
        // Task<Product> UpdateProduct(int id, ProductModel model);
        public void UpdateProduct(ProductModel UpdateProductModel);
       // Task<Product> DeleteProduct(int id);
       void DeleteProduct(int id);
        void UpdateProduct(Product updateProductModel);

        //kein public bei interfaces, da es ohnehin implementiert wird
    }
}
//role post model