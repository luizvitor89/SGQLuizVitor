using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGw.Config
{
    public class UrlsConfig
    {
        public class CIPOperations
        {
            public static string EmissorLogin() => $"/api/emissor/ValidateEmissor";
        }

        public string CIP { get; set; }
    }
}
