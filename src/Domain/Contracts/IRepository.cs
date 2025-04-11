// Domain/Contracts/IRepository.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiddingManagementSystem.Domain.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
