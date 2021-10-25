using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.DTOs;
using TodoAPI.Domain.Entities;
using TodoAPI.Domain.Repositories;
using System;
using Dapper;
using System.Data;

namespace TodoAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            string sqlQuery = "SELECT * FROM Users";
            using(var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<User>(sqlQuery);
                return users.ToList();
            }
        }

        public async Task<User> GetById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Users WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<User>(sqlQuery, new { Id = id });
            }
        }
    }
}