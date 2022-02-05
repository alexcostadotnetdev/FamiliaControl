using FamiliaControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FamiliaControl.Repository.Repository
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : BaseClass
    {
        Task Add(TEntidade entidade);
        Task AddRange(List<TEntidade> entidade);
        Task Update(TEntidade entidade);
        Task UpdateRange(List<TEntidade> entidade);
        Task Remove(Guid id);
        Task RemoveRange(List<Guid> ids);
        Task<TEntidade> GetById(Guid id);
        Task<List<TEntidade>> GetByIdRange(List<Guid> ids);
        Task<List<TEntidade>> GetAll();
        Task<List<TEntidade>> Search(Expression<Func<TEntidade, bool>> predicado);
        Task<int> SaveChanges();
    }
}
