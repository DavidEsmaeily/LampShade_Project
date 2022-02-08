using _0_Framework.Application;
using _0_Framework.Repsoitory;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context):base(context)
        {
            _context = context;
        }
        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Code = x.Code,
                CategoryId = x.CategoryId,
                DiscountRate = x.DiscountRate,
                ShortDescription = x.ShortDescription,
                UnitPrice = x.UnitPrice
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GeTList()
        {
            return _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).AsNoTracking().ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModal searchModel)
        {
            var query = _context.Products.Include(x => x.ProductCategory).Select(x => new ProductViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Name = x.Name,
                Picture = x.Picture,
                CategoryId = x.CategoryId,
                Category = x.ProductCategory.Name,
                Code = x.Code,
                UnitPrice = x.UnitPrice,
                IsInStock = x.IsInStock
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();
        }
    }
}
