// Infrastructure/Repositories/TenderRepository.cs
using BiddingManagementSystem.Domain.Contracts;
using BiddingManagementSystem.Domain.Entities;
using BiddingManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Infrastructure.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        private readonly AppDbContext _context;

        public TenderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tender entity)
        {
            await _context.Tenders.AddAsync(entity);
        }

        public void Delete(Tender entity)
        {
            _context.Tenders.Remove(entity);
        }

        public async Task<IEnumerable<Tender>> GetAllAsync()
        {
            return await _context.Tenders.AsNoTracking().ToListAsync();
        }

        public async Task<Tender?> GetByIdAsync(Guid id)
        {
            return await _context.Tenders.FindAsync(id);
        }

        public async Task<IEnumerable<Tender>> GetOpenTendersAsync()
        {
            return await _context.Tenders
                .Where(t => t.Status == Domain.Enums.TenderStatus.Open)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Tender?> GetWithBidsAsync(Guid tenderId)
        {
            return await _context.Tenders
                .Include(t => t.Bids)
                .FirstOrDefaultAsync(t => t.Id == tenderId);
        }

        public void Update(Tender entity)
        {
            _context.Tenders.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
