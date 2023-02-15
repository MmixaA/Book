using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BookDBContext bookDBContext;

        public Repository(BookDBContext dbContext)
        {
            bookDBContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await bookDBContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            bookDBContext.Set<T>().Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Delete(await GetByIdAsync(id));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await bookDBContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await bookDBContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            bookDBContext.Set<T>().Update(entity);
        }
    }
}
