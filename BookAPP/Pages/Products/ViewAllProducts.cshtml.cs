using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using BookAPP.Services.Interfaces;
using BookAPP.Services;
using BookAPP.DataDB;

namespace BookAPP.Pages.Products
{
    public class ViewAllProducts : PageModel
    {
        public List<Product> Products { get; set; } 

        private IProductService productService2;
       


        public ViewAllProducts(IProductService productService)
        {
            this.productService2 = productService;
        }

        

        public void OnGet()
        {
            Products = this.productService2.GetAll();
        }

        //public IActionResult OnPostAddProduct()
        //{
        //    return RedirectToPage("AddProduct");
        //}



    }

   
}
