using _0_Framework.Application;
using _0_Framework.Repsoitory;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext shopContext) : base(shopContext)
        {
            _context = shopContext;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _context.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                Picture  = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var querey = _context.ProductPictures.Select(x => new ProductPictureViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                IsRemoved = x.IsRemoved,
                CreationDate = x.CreationDate.ToFarsi(),
                ProductName = x.Product.Name,
                ProductId = x.ProductId
            });

            if (searchModel.ProductId > 0)
                querey = querey.Where(x => x.ProductId == searchModel.ProductId);

            return querey.AsNoTracking().OrderByDescending(x => x.Id).ToList();
        }
    }
}
