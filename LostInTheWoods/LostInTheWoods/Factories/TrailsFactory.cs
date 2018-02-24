using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using LostInTheWoods.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;


namespace LostInTheWoods.Factories
{
    public class TrailsFactory
    {
        private IOptions<MySqlOptions> _dbInfo;

        public  TrailsFactory(IOptions<MySqlOptions> dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection
        {
            get { return new MySqlConnection(_dbInfo.Value.ConnectionString); }
        }

        public List<Trail> GetTrails()
        {
            using (IDbConnection connector = Connection)
            {
                var queryString = $"Select * from trails";
                var result = connector.Query<Trail>(queryString).ToList();
                return result;

            }

        }
    }
}
