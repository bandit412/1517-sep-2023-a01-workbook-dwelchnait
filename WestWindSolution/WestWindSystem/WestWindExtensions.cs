using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.DAL;
#endregion

namespace WestWindSystem
{
    //this class MUST be static
    public static class WestWindExtensions
    {
        public static void WWExtensions(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            //we will register all the services that will be available
            //      for used by any system (services will be coded in the BLL folder)
            //we will register the database connection to be used
            //      by this class library (context setup DAL)

            //register the context service
            //the parameter options contain the connection string information
            services.AddDbContext<WestWindContext>(options);


            //register EACH service class (BLL class)
            //each service class will have an AddTransient<T>() method



            //services.AddTransient<BuildVersionServices>((serviceProvider) =>
            //{
            //    //get the Context class that was registed above (access to database)
            //    var context = serviceProvider.GetService<WestWindContext>();
            //    //create an instance of the serice class
            //    //supply the context reference to the service class constructor
            //    return new BuildVersionServices(context);
            //}
            //);
            //services.AddTransient<RegionServices>((serviceProvider) =>
            //{
            //    //get the Context class that was registed above (access to database)
            //    var context = serviceProvider.GetService<WestWindContext>();



            //    //create an instance of the serice class
            //    //supply the context reference to the service class constructor
            //    return new RegionServices(context);
            //}
            //);

            services.AddTransient<TerritoryServices>((serviceProvider) =>
                {
                    //get the Context class that was registed above (access to database)
                    var context = serviceProvider.GetService<WestWindContext>();

                    //create an instance of the serice class
                    //supply the context reference to the service class constructor
                    return new TerritoryServices(context);
                });

           // services.AddTransient<CategoryServices>((serviceProvider) =>
           // {
           //     //get the Context class that was registed above (access to database)
           //     var context = serviceProvider.GetService<WestWindContext>();



           //     //create an instance of the serice class
           //     //supply the context reference to the service class constructor
           //     return new CategoryServices(context);
           // }
           //);
           // services.AddTransient<ProductServices>((serviceProvider) =>
           // {
           //     //get the Context class that was registed above (access to database)
           //     var context = serviceProvider.GetService<WestWindContext>();



           //     //create an instance of the serice class
           //     //supply the context reference to the service class constructor
           //     return new ProductServices(context);
           // }
           //);
           // services.AddTransient<SupplierServices>((serviceProvider) =>
           // {
           //     //get the Context class that was registed above (access to database)
           //     var context = serviceProvider.GetService<WestWindContext>();



           //     //create an instance of the serice class
           //     //supply the context reference to the service class constructor
           //     return new SupplierServices(context);
           // }
           //);
        }
    }
}
