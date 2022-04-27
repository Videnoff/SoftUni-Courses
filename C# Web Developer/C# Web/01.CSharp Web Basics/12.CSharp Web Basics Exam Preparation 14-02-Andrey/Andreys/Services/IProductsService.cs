using System.Collections.Generic;
using Andreys.Models;
using Andreys.ViewModels.Products;

namespace Andreys.Services
{
    public interface IProductsService
    {
        int Add(AddProductModel productModel);

        //IEnumerable<ProductViewModel> GetAll();

        IEnumerable<Product> GetAll();

        ProductDetailsView GetDetails(int id);

        void DeleteById(int id);
    }
}