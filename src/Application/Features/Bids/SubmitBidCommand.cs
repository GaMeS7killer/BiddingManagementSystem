// Application/Features/Bids/SubmitBidCommand.cs
using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Domain.Contracts;
using BiddingManagementSystem.Domain.Entities;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Bids
{
    public record SubmitBidCommand(BidDto Dto) : IRequest<Guid>;

    public class SubmitBidHandler : IRequestHandler<SubmitBidCommand, Guid>
    {
        private readonly IBidRepository _bidRepo;
        private readonly ITenderRepository _tenderRepo;

        public SubmitBidHandler(IBidRepository bidRepo, ITenderRepository tenderRepo)
        {
            _bidRepo = bidRepo;
            _tenderRepo = tenderRepo;
        }

        public async Task<Guid> Handle(SubmitBidCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var tender = await _tenderRepo.GetByIdAsync(dto.TenderId);
            if (tender == null || tender.Deadline < DateTime.UtcNow)
                throw new Exception("Invalid or expired tender.");

            var bid = new Bid(dto.TenderId, dto.UserId, dto.Price, dto.Description);

            await _bidRepo.AddAsync(bid);
            await _bidRepo.SaveChangesAsync();

            return bid.Id;
        }
    }
}
