using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        public long ProductId { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public List<ProductViewModel> Producs { get; set; }
    }
}
