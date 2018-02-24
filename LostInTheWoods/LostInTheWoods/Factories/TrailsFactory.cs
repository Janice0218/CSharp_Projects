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

        public Trail GetTrailById(int id)
        {
            using (IDbConnection connector = Connection)
            {
                var queryString = "Select * from trails where id=@id";
                var result = connector.Query<Trail>(queryString, new {id}).SingleOrDefault();
                return result;
            }
        }

        public void CreateTrail(Trail trail)
        {
            using (IDbConnection connector = Connection)
            {
                var queryString =
                    @"INSERT INTO trails(name,description,length,elevationChange,longitude,latitude,createdAt,updatedAt) VALUES(@name, @description, @length, @elevationChange, @longitude, @latitude,now(),now())";
                var result = connector.Execute(queryString, trail);
            }
        }

        public void UpdateTrail(Trail trail)
        {
            using (IDbConnection connector = Connection)
            {
                var queryString = "UPDATE trails SET name=@name,description=@description,length=@length,elevationChange=@elevationChange,longitude=@longitude,latitude=@latitude,updatedat=now()";
                var result = connector.Execute(queryString, trail);
            }
        }

        public void deleteTrail(int id)
        {
            using (IDbConnection connector = Connection)
            {
                var queryString = "DELETE FROM trails WHERE id=@id";
                var result = connector.Execute(queryString, new {id});
            }
        }
    }
}
