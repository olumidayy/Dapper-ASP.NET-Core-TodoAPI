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
    public class TodoRepository : ITodoRepository
    {
        private readonly DapperContext _context;
        public TodoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task Create(CreateTodoDTO createTodoDTO, Guid userId)
        {
            string sqlQuery = "INSERT into Todos (UserId, Title, Description, Id) values (@UserId, @Title, @Description, @Id)";
            var parameters = new DynamicParameters();
            parameters.Add("Title", createTodoDTO.Title, DbType.String);
            parameters.Add("UserId", createTodoDTO.UserId, DbType.Guid);
            parameters.Add("Description", createTodoDTO.Description, DbType.String);
            parameters.Add("Id", Guid.NewGuid(), DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            string sqlQuery = "SELECT * FROM Todos";
            using (var connection = _context.CreateConnection())
            {
                var todos = await connection.QueryAsync<TodoItem>(sqlQuery);
                return todos.ToList();
            }
        }

        public async Task<TodoItem> GetById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Todos WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var todo = await connection.QuerySingleAsync<TodoItem>(sqlQuery);
                return todo;
            }
        }

        public async Task<IEnumerable<TodoItem>> GetByUser(Guid id)
        {
            string sqlQuery = "SELECT * FROM Todos WHERE UserId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var todos = await connection.QueryAsync<TodoItem>(sqlQuery, new { UserId = id });
                return todos;
            }
        }

        public async Task Update(UpdateTodoDTO updateTodoDTO, Guid id)
        {
            string sqlQuery = "UPDATE Todos SET Title = @Title, Status = @Status, Description = @Description WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Title", updateTodoDTO.Title, DbType.String);
            parameters.Add("Status", updateTodoDTO.Status, DbType.String);
            parameters.Add("Description", updateTodoDTO.Description, DbType.String);
            parameters.Add("Id", id, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }

        public async Task Delete(Guid id)
        {
            string query = "DELETE FROM Todos WHERE Id = @Id";

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, new { Id = id });
            }
			
        }
    }
}