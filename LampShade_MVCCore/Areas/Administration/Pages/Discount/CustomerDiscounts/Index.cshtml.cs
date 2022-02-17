using System.Collections.Generic;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace LampShade_MVCCore.Pages.Discount.CustomerDiscounts
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CustomerDiscountSearchModel SearchModel { get; set; }

        public SelectList Products { get; set; }

        public List<CustomerDiscountViewModel> CustomerDiscounts { get; set; }
        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(ICustomerDiscountApplication customerDiscountApplication, IProductApplication productApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            CustomerDiscounts = _customerDiscountApplication.Search(searchModel);
            Products = new SelectList(_productApplication.GetList(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var product = new DefineCustomerDiscount
            {
                Products = _productApplication.GetList()
            };
            return Partial("./Create" , product);
        }

        public IActionResult OnGetEdit(long id)
        {
            var discount = _customerDiscountApplication.GetDetails(id);
            discount.Products = _productApplication.GetList();
            return Partial("./Edit", discount);
        }

        public IActionResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Define(command);
            return new JsonResult(result);
        }


        public IActionResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Edit(command);

            return new JsonResult(result);
        }

        //public IActionResult OnGetHasInStock(long id)
        //{
        //    var result = _productApplication.HasInStock(id);
        //    if (result.IsSucceeded)
        //        return RedirectToPage("./Index");
        //    return RedirectToPage("./Index");
        //}

        // public IActionResult OnGetNotInStock(long id)
        //{
        //    var result = _productApplication.NotInStock(id);
        //    if (result.IsSucceeded)
        //        return RedirectToPage("./Index");
        //    return RedirectToPage("./Index");
        //}
    }
}
