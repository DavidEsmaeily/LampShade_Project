using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;

namespace LampShade_MVCCore.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        [BindProperty] public ProductCategorySearchModel
 SearchModel { get; set; }

        public List<ProductCategoryViewModel> ProductCategories { get; set; }
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel
 searchModel)
        {

            ProductCategories = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productCategoryApplication.GetDetails(id);
            return Partial("./Edit", productCategory);
        }

        public IActionResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }


        public IActionResult OnPostEdit(EditProductCategory command)
        {
            var result = _productCategoryApplication.Edit(command);
           
            return new JsonResult(result);
        }
    }
}
