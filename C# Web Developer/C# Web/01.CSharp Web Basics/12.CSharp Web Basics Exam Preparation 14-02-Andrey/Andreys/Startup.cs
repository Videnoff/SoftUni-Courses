using System.Collections.Generic;
using Andreys.Data;
using Andreys.Services;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys
{
    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> serverRoutingTable)
        {
            using var db = new AndreysDbContext();
            db.Database.EnsureCreated();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProductsService, ProductsService>();
        }
    }
}
