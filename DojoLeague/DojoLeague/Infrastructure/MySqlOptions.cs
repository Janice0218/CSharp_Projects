//used to map the appsettings.json connection string to a cs object so it can be used as a service and passed to other parts of application

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DojoLeague.Models
{
    public class MySqlOptions
    {
        public string DefaultConnection { get; set; }
    }
}
