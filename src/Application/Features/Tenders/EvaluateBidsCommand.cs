// Application/Features/Tenders/EvaluateBidsCommand.cs
using BiddingManagementSystem.Domain.Contracts;
using BiddingManagementSystem.Domain.Entities;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders
{
    public record EvaluateBidsCommand(Guid TenderId) : IRequest<string>;

    public class EvaluateBidsHandler : IRequestHandler<EvaluateBidsCommand, string>
    {
        private readonly ITenderRepository _tenderRepo;
        private readonly IBidRepository _bidRepo;

        public EvaluateBidsHandler(ITenderRepository tenderRepo, IBidRepository bidRepo)
        {
            _tenderRepo = tenderRepo;
            _bidRepo = bidRepo;
        }

        public async Task<string> Handle(EvaluateBidsCommand request, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepo.GetWithBidsAsync(request.TenderId);
            if (tender == null)
                throw new Exception("Tender not found.");

            if (!tender.Bids.Any())
                return "No bids submitted.";

            // Select lowest bid
            var winningBid = tender.Bids.OrderBy(b => b.Price).First();
            winningBid.MarkAsWinner();

            tender.AwardTender();

            await _bidRepo.SaveChangesAsync();
            await _tenderRepo.SaveChangesAsync();

            return $"Tender awarded to bidder {winningBid.User.FullName} with bid {winningBid.Price:C}";
        }
    }
}
