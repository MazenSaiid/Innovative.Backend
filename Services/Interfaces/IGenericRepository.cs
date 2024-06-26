﻿
using Innovative.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innovative.Backend.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity<int>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(int id , T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
 
    }
}
