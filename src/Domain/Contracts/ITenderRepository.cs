// Domain/Contracts/ITenderRepository.cs
using BiddingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiddingManagementSystem.Domain.Contracts
{
    public interface ITenderRepository : IRepository<Tender>
    {
        Task<IEnumerable<Tender>> GetOpenTendersAsync();
        Task<Tender?> GetWithBidsAsync(Guid tenderId);
    }
}
