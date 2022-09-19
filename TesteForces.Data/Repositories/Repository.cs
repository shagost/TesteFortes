using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Data.Context;
using TesteFortes.Domain.Entities;
using TesteFortes.Domain.Interfaces;
using TesteFortes.Domain.Models;

namespace TesteFortes.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public TEntity Create(TEntity model)
        {
            DbSet.Add(model);
            Save();
            return model;
        }

        public async Task<TEntity> CreateAsync(TEntity model)
        {
            await DbSet.AddAsync(model);
            Save();
            return model as TEntity;
        }

        public bool Delete(TEntity model)
        {
            if (model is Entity)
            {
                (model as Entity).IsActive = false;
                var _entry = _context.Entry(model);
                DbSet.Attach(model);
                _entry.State = EntityState.Modified;
            }
            else
            {
                var _entry = _context.Entry(model);
                DbSet.Attach(model);
                _entry.State = EntityState.Deleted;
            }

            return Save() > 0;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();

            GC.SuppressFinalize(this);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.AsNoTracking().FirstOrDefault(where);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes)
        {
            IQueryable<TEntity> _query = DbSet;

            if (includes != null)
                _query = includes(_query) as IQueryable<TEntity>;

            return _query.AsNoTracking().FirstOrDefault(predicate);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(TEntity model)
        {
            var entry = _context.Entry(model);
            DbSet.Attach(model);
            entry.State = EntityState.Modified;
            return Save() > 0; 
        }

        public async Task<int> SaveAsync()
        {
            var entry = await _context.SaveChangesAsync();
            return entry;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return DbSet.Where(where).AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes)
        {
            try
            {
                IQueryable<TEntity> _query = DbSet;

                if (includes != null)
                    _query = includes(_query) as IQueryable<TEntity>;

                return _query.Where(where).AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
