using CarBookApp.Application.Interfaces;
using CarBookApp_Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp_Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class

    {
        private readonly CarBookAppContext _appContext;

        public Repository(CarBookAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task CreateAsync(T entity)
        {
            _appContext.Set<T>().Add(entity);
           await _appContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _appContext.Set<T>().Remove(entity);
            await _appContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _appContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _appContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _appContext.Set<T>().Update(entity);
            await _appContext.SaveChangesAsync();
        }
    }
}
