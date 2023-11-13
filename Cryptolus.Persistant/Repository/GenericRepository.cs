using Cryptolus.Application.Common.Interfaces.Repositories;
using Cryptolus.Domain.Common.Interfaces;
using Cryptolus.Persistant.Data.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Persistant.Repository
{ 
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        protected readonly CryptolusContext _dbContext;

        public GenericRepository(CryptolusContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        { 
            if(await _dbContext.Set<T>().AnyAsync(x => x.Id == entity.Id))
                throw new Exception();

            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            if(!_dbContext.Set<T>().AnyAsync(x => x.Id == entity.Id).Result)
                throw new Exception();

            T exist = _dbContext.Set<T>().Find(entity.Id);
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            if(!_dbContext.Set<T>().AnyAsync(x => x.Id == entity.Id).Result)
                throw new Exception("not find user");

            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }


        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext
                .Set<T>()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);

            if(result == null)
                throw new Exception();

            return result;
        }

        
    }
}
