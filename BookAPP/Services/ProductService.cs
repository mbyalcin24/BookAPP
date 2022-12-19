using BookAPP.DataDB;
using BookAPP.Services.Interfaces;
using System.Runtime.CompilerServices;
using BookAPP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAPP.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Linq;

namespace BookAPP.Services


    //                                          CRUD with Interfaces
{
    public class ProductService : IProductService


    {
        public List<Product> GetAll()
        {
            var context = DbContextforServices.CreateContext();

            return context.Products.ToList();
        }


        public async Task<Product> CreateProduct(ProductModel model) {

            var newproduct = new Product
            {
                Category = model.Category,
                Name = model.Name,
                Price = model.Price
            };
            using (var context = DbContextforServices.CreateContext())
            {
                context.Products.Add(newproduct);
                await context.SaveChangesAsync();
            }

           
            return newproduct; //return wert ist liste

            //Testkommentar für Github update
            
        }
        public  Product ReadProduct(int id) {  //model klasse für user input
            var context = DbContextforServices.CreateContext();

            //var productToDisplay = context.Products.FirstOrDefaultAsync(p => p.ID == id);
            return context.Products.FirstOrDefault(p => p.ID == id);
                //if (productToDisplay == null) { 

            //    return null;

            //}

            //return productToDisplay;


            // return <productToDisplay>; //nur ein Objekt, sollte list sein <>

        }
        public async Task<Product> UpdateProduct(int id, ProductModel model) {

            var context = DbContextforServices.CreateContext();
            var currentProduct = await context.Products.FindAsync(id);

            //if (currentProduct == null) {

            //    return null;
            
            //}

            currentProduct.Name = model.Name;
            currentProduct.Price = model.Price;
            currentProduct.Category = model.Category;

            await context.SaveChangesAsync();


          
           return currentProduct;




        }
        public void UpdateProduct(ProductModel UpdateProductModel) {

            var context = DbContextforServices.CreateContext();

            context.Entry(UpdateProductModel).State = EntityState.Modified;
            context.SaveChanges();

        }
        public void DeleteProduct(int id) {

            var context = DbContextforServices.CreateContext();

            var product2 = context.Products.FirstOrDefault(p => p.ID == id);

           

            context.Products.Remove(product2);
            context.SaveChangesAsync();
           
        }

        public void UpdateProduct(Product updateProductModel)
        {
            var context = DbContextforServices.CreateContext();

            context.Entry(updateProductModel).State = EntityState.Modified;
            context.SaveChanges();
        }

        //Task<Product> IProductService.DeleteProduct(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

