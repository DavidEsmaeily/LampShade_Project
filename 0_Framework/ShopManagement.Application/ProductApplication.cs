using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.UnitPrice, command.Code , command.ShortDescription ,
                command.Description, command.DiscountRate,command.Picture , command.PictureAlt , command.PictureTitle ,
                command.Keywords , command.MetaDescription , slug , command.CategoryId);

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var product = _productRepository.Get(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.UnitPrice, command.Code, command.ShortDescription,
                command.Description, command.DiscountRate, command.Picture, command.PictureAlt, command.PictureTitle,
                command.Keywords, command.MetaDescription, slug, command.CategoryId);

            _productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetList()
        {
            return _productRepository.GeTList();
        }

        public OperationResult HasInStock(long id)
        {
            var operation = new OperationResult();
 
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            product.HasInStock();

            _productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();

            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            product.NotInStock();

            _productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public List<ProductViewModel> Search(ProductSearchModal searchModal)
        {
            return _productRepository.Search(searchModal);
        }
    }
}
