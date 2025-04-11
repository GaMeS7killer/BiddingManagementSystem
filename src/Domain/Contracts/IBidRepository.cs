// Domain/Contracts/IBidRepository.cs
using BiddingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiddingManagementSystem.Domain.Contracts
{
    public interface IBidRepository : IRepository<Bid>
    {
        Task<IEnumerable<Bid>> GetBidsForTenderAsync(Guid tenderId);
        Task<Bid?> GetWinningBidAsync(Guid tenderId);
    }
}
