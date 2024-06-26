﻿
using Innovative.Backend.Core.Entities;
using Innovative.Backend.Data.Context;
using Innovative.Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innovative.Backend.Services.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity<int>
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var entityToDelete = await _context.Set<T>().FindAsync(id);
            if(entityToDelete is not null)
            {
                _context.Set<T>().Remove(entityToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
           await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(int id) =>
            await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);


        public async Task UpdateAsync(int id, T entity)
        {
            var entityToUpdate = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entityToUpdate is not null) 
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                 
            }
        }
    }
}
