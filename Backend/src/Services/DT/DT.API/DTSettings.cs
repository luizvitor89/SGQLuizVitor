using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT.API
{
    public class DTSettings
    {
        public string ExternalCatalogBaseUrl { get; set; }
        public string EventBusConnection { get; set; }
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
