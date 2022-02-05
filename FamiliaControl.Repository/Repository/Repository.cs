using FamiliaControl.Domain.Models;
using FamiliaControl.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FamiliaControl.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseClass, new()
    {
        protected readonly FamilyControlDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(FamilyControlDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task<List<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking()
                               .Where(predicate)
                               .ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            entity.Active = true;
            entity.Create = DateTime.Now;

            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task AddRange(List<TEntity> entitys)
        {
            entitys.ForEach(entity =>
            {
                entity.Active = true;
                entity.Create = DateTime.Now;
            });

            _dbSet.AddRange(entitys);
            await SaveChanges();
        }

        public virtual async Task UpdateRange(List<TEntity> entitys)
        {
            entitys.ForEach(entity =>
            {
                entity.LastUpdate = DateTime.Now;
            });

            _dbSet.UpdateRange(entitys);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            entity.LastUpdate = DateTime.Now;
            entity.Active = true;

            _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(Guid id)
        {
            var entity = await GetById(id);
            if (entity == null)
                return;

            entity.Active = false;
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task RemoveRange(List<Guid> ids)
        {
            var entitys = await GetByIdRange(ids);
            if (entitys == null || entitys.Count == 0)
                return;

            entitys.ForEach(p =>
            {
                p.Active = false;
            });

            _dbSet.UpdateRange(entitys);
            await SaveChanges();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.AsNoTracking()
                               .FirstOrDefaultAsync(p => p.Id == id && p.Active);
        }

        public virtual async Task<List<TEntity>> GetByIdRange(List<Guid> ids)
        {
            return await _dbSet.AsNoTracking()
                               .Where(p => ids.Any(q => q == p.Id && p.Active))
                               .ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.AsNoTracking()
                               .Where(p => p.Active)
                               .ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
