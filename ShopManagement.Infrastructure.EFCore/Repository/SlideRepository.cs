using _0_Framework.Application;
using _0_Framework.Repsoitory;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Heading = x.Heading,
                Link = x.Link,
                Text = x.Text,
                Title = x.Title,
                BtnText = x.BtnText
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> GetSlides()
        {
            return _context.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Heading = x.Heading,
                Title = x.Title,
                BtnText = x.BtnText,
                IsRemoved = x.IsRemoved,
                CreationDate = x.CreationDate.ToFarsi()
            }).AsNoTracking().OrderByDescending(x => x.Id).ToList();
        }
    }

}
