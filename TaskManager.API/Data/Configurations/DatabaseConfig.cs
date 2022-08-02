using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.API.Data.Configurations
{
    public class DatabaseConfig : IDatabaseConfig
    {
        public string DatabaseName { get ; set; }
        public string ConnectionString { get ; set ; }
    }
}
