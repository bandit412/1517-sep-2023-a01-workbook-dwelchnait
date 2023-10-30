using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class BuildVersionServices
    {
        #region setup the context connection variable and class constructor
        //this is connection variable to be used within this class
        private readonly WestWindContext _context;

        //constructor to be used in the creation of the instance of this class
        //the registered reference for the context connection (database connection)
        //  will be passed from the IServiceCollection registered services
        internal BuildVersionServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion
    
        //Services (a.k.a. method)
        //this is a service method within this class
        //this service will need access to a DbSet<>
        //the DbSet<>s are located in your DbContent class which will be referenced
        //  using the _context
        //BY DEFAULT, ALL records of the sql table will be returned from the DbSet
        //We will use Linq queries to limit the return of data
        //this class will associate its work with the BuildVersion entities

        public BuildVersion BuildVersion_GetVersion()
        {
            return _context.BuildVersions.FirstOrDefault();
        }
    }
}
