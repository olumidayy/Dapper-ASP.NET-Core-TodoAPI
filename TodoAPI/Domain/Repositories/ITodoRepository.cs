using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.DTOs;
using TodoAPI.Domain.Entities;
using TodoAPI.Data;
using System;

namespace TodoAPI.Domain.Repositories
{
    public interface ITodoRepository
    {
        public Task Create(CreateTodoDTO createTodoDTO, Guid userId);

        public Task<IEnumerable<TodoItem>> GetAll();
        
        public Task<TodoItem> GetById(Guid id);

        public Task<IEnumerable<TodoItem>> GetByUser(Guid id);

        public Task Update(UpdateTodoDTO projectDTO, Guid id);

        public Task Delete(Guid id);
    }
}