using _0_Framework.Application;
using System.Collections;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        OperationResult HasInStock(long id);
        OperationResult NotInStock(long id);
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModal searchModal);
        List<ProductViewModel> GetList();
    }
}
