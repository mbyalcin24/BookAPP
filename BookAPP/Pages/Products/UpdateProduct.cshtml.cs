using BookAPP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookAPP.DataDB;

namespace BookAPP.Pages.Products
{
    public class UpdateProduct : PageModel
    {
        private IProductService productService2;
        private IWebHostEnvironment webEnv;

        public UpdateProduct(IProductService productService, IWebHostEnvironment environment)
        {
            this.productService2 = productService;
            this.webEnv = environment;
        }

        [FromRoute]
        public int Id { get; set; }

        [BindProperty]
        public Product UpdateProductModel { get; set; }

        public void OnGet() //dies sorgt dafür, dass auf der Edit-page die Felder mit den aktuellen Werten gefüllt ist
        {
            UpdateProductModel = this.productService2.ReadProduct(Id);
        }

        public async Task<IActionResult> OnPost() //alle asp-page-handler rufen alle OnPost methoden auf
        {
            if (ModelState.IsValid)
            {
                UpdateProductModel.ID = Id;
                this.productService2.UpdateProduct(UpdateProductModel);
                return RedirectToPage("ViewAllProducts");
            }

            return Page();
        }

        public IActionResult OnPostDelete() //auch diese methode wird dank asp-page-handler aufgerufen
        {
            this.productService2.DeleteProduct(Id);

            return RedirectToPage("ViewAllProducts");

        }

    }


}

