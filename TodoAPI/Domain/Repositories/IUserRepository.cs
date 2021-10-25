using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Domain.Entities;

namespace TodoAPI.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAll();

        public Task<User> GetById(Guid id);
    }
}