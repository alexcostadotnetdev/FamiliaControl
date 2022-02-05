using FamiliaControl.Domain.Models;
using FamiliaControl.Repository;
using FamiliaControl.Repository.Repository;
using FamiliaControl.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FamiliaControl.Service
{
    public class UserServices : IUserServices
    {
        private readonly Repository<User> _repository;

        public UserServices(Repository<User> repository)
        {
            _repository = repository;
        }

        public Task Add(User entidade)
        {
            return _repository.Add(entidade);
        }

        public Task AddRange(List<User> entidade)
        {
            return _repository.AddRange(entidade);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<List<User>> GetAll()
        {
            return await _repository.GetAll();
        }

        public Task<User> GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Task<List<User>> GetByIdRange(List<Guid> ids)
        {
            return _repository.GetByIdRange(ids);
        }

        public Task Remove(Guid id)
        {
            return _repository.Remove(id);
        }

        public Task RemoveRange(List<Guid> ids)
        {
            return _repository.RemoveRange(ids);
        }

        public Task<int> SaveChanges()
        {
            return _repository.SaveChanges();
        }

        public Task<List<User>> Search(Expression<Func<User, bool>> predicado)
        {
            return _repository.Search(predicado);
        }

        public Task Update(User entidade)
        {
            return _repository.Update(entidade);
        }

        public Task UpdateRange(List<User> entidade)
        {
            return _repository.UpdateRange(entidade);
        }
    }
}
