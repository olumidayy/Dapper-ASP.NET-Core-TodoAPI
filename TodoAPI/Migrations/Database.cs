using System;
using System.Linq;
using Dapper;
using TodoAPI.Data;

namespace TodoAPI.Migrations
{
    public class Database
    {
        private readonly DapperContext _context;
        public Database(DapperContext context)
        {
            _context = context;
        }
        public void CreateDatabase(string dbName)
        {
            var query = "SELECT * FROM sys.databases WHERE name = @name";
            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);
            using (var connection = _context.CreateConnection())
            {
                var records = connection.Query(query, parameters);
                if (!records.Any()) 
                {
                    connection.Execute($"CREATE DATABASE {dbName}");
                    Console.WriteLine(String.Format("Databse {} has been created", dbName));
                }
            }
        }
    }
}