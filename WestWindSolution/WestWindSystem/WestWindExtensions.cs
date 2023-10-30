using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.BLL;
#endregion

namespace WestWindSystem
{
    public static class WestWindExtensions
    {
        //setup the extension method for this library
        public static void WWExtensions(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            //IServiceCollection
            //we will register all the services that will be available
            //  for used by any system using this library
            //services will be coded in the BLL folder within individual
            //  classes related to the Entity (course standard)

            //DbContext connection
            //we will register the database connection to be used
            //  by any service requiring access to the database

            //register the context service
            //the parameter options contain the connection string information
            services.AddDbContext<WestWindContext>(options);

            //register services
            //EACH service class MUST be registered for use by the outside world
            //each service class will have its own AddTransient<T>() method

            services.AddTransient<BuildVersionServices>((serviceProvider) =>
                {
                    //get the Context class that was registed above
                    var context = serviceProvider.GetService<WestWindContext>();

                    //create an instance of the service class
                    //supply the context reference to the service class constructor
                    return new BuildVersionServices(context);
                }
            );

            //services.AddTransient<TerritoryServices>((serviceProvider) =>
            //    {
            //        //get the Context class that was registed above
            //        var context = serviceProvider.GetService<WestWindContext>();

            //        //create an instance of the service class
            //        //supply the context reference to the service class constructor
            //        return new TerritoryServices(context);
            //    }
            //);
        }
    }
}
