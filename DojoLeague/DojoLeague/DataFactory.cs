//this class is used to create a DbConnection object (implementing the IDbconnection interface) to use as a cs object that represents a connection to the DB

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DojoLeague.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Dapper;

namespace DojoLeague
{
    public class DataFactory
    {
        private IOptions<MySqlOptions> _connStr;

        public DataFactory(IOptions<MySqlOptions> connStr)
        {
            _connStr = connStr;
        }

        //cs object that is used throughout app as the connection to a specific relational DB
        public IDbConnection Connection
        {
            get
            {
                //when the Connection property is used, it will return a MySqlConnection object configured with the connection string from appsettings.json, passed in thru MySqlOptions by dependency injection
                return new MySqlConnection(_connStr.Value.DefaultConnection);
            }
        }

        //retrieve query using dapper method which returns an IEnum object from DB, which is then cast to a list.
        public List<Ninjas> GetNinjas()
        {
            var queryString = "SELECT * FROM ninjas";
           var result = Connection.Query<Ninjas>(queryString).ToList();
            return result;
        }

        public void AddNinja(Ninjas ninja)
        {
            var queryString =
                "INSERT INTO ninjas(name, level, dojo, description, createdat, updatedat) VALUES(@name, @level, @dojo, @description, now(), now())";
            var result = Connection.Execute(queryString, ninja);
        }

        public List<Dojos> GetDojos()
        {
            var queryString = "SELECT * FROM dojos";
            var result = Connection.Query<Dojos>(queryString).ToList();
            return result;
        }

        public void AddDojo(Dojos dojo)
        {
            var queryString =
                "INSERT INTO dojos(name, location, description) VALUES(@name, @location, @description)";
            var result = Connection.Execute(queryString, dojo);
        
        }

        public Ninjas GetNinjaById(int id)
        {
            var queryString = @"SELECT * FROM ninjas WHERE id=@id";
            var result = Connection.Query<Ninjas>(queryString, new {id}).FirstOrDefault();
            return result;
        }
        public Dojos GetDojoByLocation(string id)
        {
            var queryString = @"SELECT * FROM dojos WHERE location=@id";
            var result = Connection.Query<Dojos>(queryString, new { id }).FirstOrDefault();
            return result;
        }
    }
}
