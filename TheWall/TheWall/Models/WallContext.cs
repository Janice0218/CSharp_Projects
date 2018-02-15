//dbcontext file that will contain the connections to the db data

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TheWall.Models
{
    public class WallContext
    
    {   //constructor takes a copy of connection string that will be passed in from the services app (creates dependency inJ)
        public WallContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        //constructor sets this property to a copy that is designated in services(startup file)
        public string ConnectionString { get; set; }
        //this is the object from the MySql Data class that takes in the Connection string and used the information to make the connection
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        
    }


}
