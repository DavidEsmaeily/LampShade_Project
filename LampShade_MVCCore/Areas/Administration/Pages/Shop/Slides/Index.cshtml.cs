using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.Slide;

namespace LampShade_MVCCore.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        public List<SlideViewModel> Slides { get; set; }
        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {

            Slides = _slideApplication.GetSlides();
            
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide = _slideApplication.GetDetails(id);
            return Partial("./Edit", slide);
        }

        public IActionResult OnPostCreate(CreateSlide command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }


        public IActionResult OnPostEdit(EditSlide command)
        {
            var result = _slideApplication.Edit(command);

            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _slideApplication.Remove(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Index");
        }

         public IActionResult OnGetRestore(long id)
        {
            var result = _slideApplication.Restore(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Index");
        }
    }
}
