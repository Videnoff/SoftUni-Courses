using Andreys.Services;
using Andreys.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsService productsService;

        public ProductsController(ProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddProductModel productModel)
        {
            // TODO: Add validation

            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (productModel.Name.Length < 4 || productModel.Name.Length > 20)
            {
                return this.View();
            }

            if (string.IsNullOrEmpty(productModel.Description) || productModel.Description.Length > 10)
            {
                return this.View();
            }

            var productId = this.productsService.Add(productModel);

            return this.Redirect($"/Products/Details?id={productId}");
        }

        public HttpResponse Details(int productId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var product = this.productsService.GetDetails(productId);

            return this.View(product);
        }
        public HttpResponse Delete(int productId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productsService.DeleteById(productId);

            return this.Redirect("/");
        }
    }
}