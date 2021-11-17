using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.DTOs;
using TodoAPI.Domain.Entities;
using System;

namespace TodoAPI.Domain.Repositories
{
    public interface ITodoRepository
    {
        public Task<Guid> Create(CreateTodoDTO createTodoDTO, Guid userId);

        public Task<IEnumerable<TodoItem>> GetAll();
        
        public Task<TodoItem> GetById(Guid id);

        public Task<IEnumerable<TodoItem>> GetByUser(Guid id);

        public Task Update(UpdateTodoDTO projectDTO, Guid id);

        public Task Delete(Guid id);
    }
}