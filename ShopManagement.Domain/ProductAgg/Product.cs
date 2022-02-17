using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public Product(string name, double unitPrice, string code,
            string shortDescription, string description, int discountRate,
            string picture, string pictureAlt, string pictureTitle,
            string keywords, string metaDescription, string slug, long categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            DiscountRate = discountRate;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
            IsInStock = true;
        }

        public void Edit(string name, double unitPrice, string code,
            string shortDescription, string description, int discountRate,
            string picture, string pictureAlt, string pictureTitle,
            string keywords, string metaDescription, string slug, long categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            DiscountRate = discountRate;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
        }

        public void HasInStock()
        {
            IsInStock = true;
        }

        public void NotInStock()
        {
            IsInStock = false;
        }


        public string Name { get; private set; }
        public double UnitPrice { get; private set; }
        public string Code { get; private set; }
        public bool IsInStock { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public int DiscountRate { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory ProductCategory { get; private set; }
        public List<ProductPicture> ProductPictures { get; private set; }

    }
}
