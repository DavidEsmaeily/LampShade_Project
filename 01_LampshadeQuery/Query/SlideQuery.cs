using _01_LampshadeQuery.Contracts.Slide;
using ShopManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_LampshadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _context;

        public SlideQuery(ShopContext context)
        {
            _context = context;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _context.Slides.Where(x => !x.IsRemoved).Select(x => new SlideQueryModel
            {
                Id = x.Id,
                Heading = x.Heading,
                Link = x.Link,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                Text = x.Text,
                Title = x.Title,
                PictureTitle = x.PictureTitle,
                BtnText = x.BtnText
            }).ToList();
        }
    }
}
