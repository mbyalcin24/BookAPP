using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookAPP.DataDB;
using BookAPP.Services.Interfaces;
using BookAPP.Models;

namespace BookAPP.Pages.Products
{
    public class AddProductModel : PageModel
    {
        private IProductService productServ;
        private IWebHostEnvironment webEnv;

        public AddProductModel(IProductService productService, IWebHostEnvironment environment)
        {
            this.productServ = productService;
            this.webEnv = environment;
        }

        [BindProperty]
        public ProductModel NewProductmodel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await this.productServ.CreateProduct(NewProductmodel);
                return RedirectToPage("ViewAllProducts");
            }

            return Page();
        }
    }
}
