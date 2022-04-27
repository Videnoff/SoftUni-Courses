using System;
using System.Collections.Generic;
using System.Linq;
using Andreys.Data;
using Andreys.Enums;
using Andreys.Models;
using Andreys.ViewModels.Products;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext dbContext;

        public ProductsService(AndreysDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(AddProductModel productModel)
        {
            var genderAsEnum = Enum.Parse<Gender>(productModel.Gender);
            var categoryAsEnum = Enum.Parse<Category>(productModel.Category);

            var product = new Product
            {
                Category = categoryAsEnum,
                Description = productModel.Description,
                Gender = genderAsEnum,
                ImageUrl = productModel.ImageURL,
                Name = productModel.Name,
                Price = productModel.Price
            };

            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();

            return product.Id;
        }

        public IEnumerable<Product> GetAll() => this.dbContext.Products
            .Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            }).ToArray();


        //public IEnumerable<ProductViewModel> GetAll()
        //{
        //    var products = this.dbContext.Products
        //        .Select(x => new ProductViewModel
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            ImageUrl = x.ImageUrl,
        //            Price = x.Price
        //        })
        //        .ToArray();

        //    return products;
        //}

        public ProductDetailsView GetDetails(int id)
        {
            var product = this.dbContext.Products
                .Where(x => x.Id == id)
                .Select(x => new ProductDetailsView
                {
                    Id = x.Id,
                    Name = x.Name,
                    Gender = x.Gender,
                    Category = x.Category,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Price = x.Price
                })
                .FirstOrDefault();

            return product;
        }

        public void DeleteById(int id)
        {
            var product = this.dbContext.Products
                .FirstOrDefault(x => x.Id == id);
            this.dbContext.Products.Remove(product);
            this.dbContext.SaveChanges();
        }
    }
}