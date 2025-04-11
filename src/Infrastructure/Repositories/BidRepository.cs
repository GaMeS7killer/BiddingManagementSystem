// Infrastructure/Repositories/BidRepository.cs
using BiddingManagementSystem.Domain.Contracts;
using BiddingManagementSystem.Domain.Entities;
using BiddingManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Infrastructure.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext _context;

        public BidRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Bid entity)
        {
            await _context.Bids.AddAsync(entity);
        }

        public void Delete(Bid entity)
        {
            _context.Bids.Remove(entity);
        }

        public async Task<IEnumerable<Bid>> GetAllAsync()
        {
            return await _context.Bids.AsNoTracking().ToListAsync();
        }

        public async Task<Bid?> GetByIdAsync(Guid id)
        {
            return await _context.Bids.FindAsync(id);
        }

        public async Task<IEnumerable<Bid>> GetBidsForTenderAsync(Guid tenderId)
        {
            return await _context.Bids
                .Where(b => b.TenderId == tenderId)
                .Include(b => b.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Bid?> GetWinningBidAsync(Guid tenderId)
        {
            return await _context.Bids
                .Where(b => b.TenderId == tenderId && b.IsWinner)
                .Include(b => b.User)
                .FirstOrDefaultAsync();
        }

        public void Update(Bid entity)
        {
            _context.Bids.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
