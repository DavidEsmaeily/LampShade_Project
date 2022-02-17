using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace LampShade_MVCCore.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ProductSearchModal SearchModel { get; set; }
        public SelectList ProductCategories { get; set; }

        public List<ProductViewModel> Products { get; set; }
        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly IProductApplication _productApplication;


        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;

            _productApplication = productApplication;
        }

        public void OnGet(ProductSearchModal searchModel)
        {

            Products = _productApplication.Search(searchModel);
            ProductCategories = new SelectList(_productCategoryApplication.GetList(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var product = new CreateProduct
            {
                Categories = _productCategoryApplication.GetList()
            };
            return Partial("./Create" , product);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _productApplication.GetDetails(id);
            product.Categories = _productCategoryApplication.GetList();
            return Partial("./Edit", product);
        }

        public IActionResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }


        public IActionResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);

            return new JsonResult(result);
        }

        public IActionResult OnGetHasInStock(long id)
        {
            var result = _productApplication.HasInStock(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Index");
        }

         public IActionResult OnGetNotInStock(long id)
        {
            var result = _productApplication.NotInStock(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Index");
        }
    }
}
