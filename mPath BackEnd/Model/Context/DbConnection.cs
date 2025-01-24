using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public partial class DbConnection : DbContext
    {
        private DbConnection(string connectionString)
            : base(connectionString)
        { 
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Database.CommandTimeout = 900;
        }

        public static DbConnection Create()
        {
            return new DbConnection("name=DbConnection");
        }
    }
}
