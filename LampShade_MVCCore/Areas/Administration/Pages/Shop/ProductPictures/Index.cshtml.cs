using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;

namespace LampShade_MVCCore.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ProductPictureViewModel SearchModel { get; set; }
        public SelectList Products { get; set; }

        public List<ProductPictureViewModel> ProductPictures { get; set; }
        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            this._productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {

            ProductPictures = _productPictureApplication.Search(searchModel);
            Products = new SelectList(_productApplication.GetList(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var productPicture = new CreateProductPicture
            {
                Producs = _productApplication.GetList()
            };
            return Partial("./Create" , productPicture);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productPicture = _productPictureApplication.GetDetails(id);
            productPicture.Producs = _productApplication.GetList();
            return Partial("./Edit", productPicture);
        }

        public IActionResult OnPostCreate(CreateProductPicture command)
        {
            var result = _productPictureApplication.Create(command);
            return new JsonResult(result);
        }


        public IActionResult OnPostEdit(EditProductPicture command)
        {
            var result = _productPictureApplication.Edit(command);

            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _productPictureApplication.Remove(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Index");
        }

         public IActionResult OnGetRestore(long id)
        {
            var result = _productPictureApplication.Restore(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Index");
        }
    }
}
