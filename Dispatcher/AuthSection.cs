using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dispatcher
{
    public class AuthSection
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string KeyPublic { get; set; }
    }
}
