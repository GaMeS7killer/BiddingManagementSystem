// Application/Features/Tenders/GetOpenTendersQuery.cs
using BiddingManagementSystem.Domain.Contracts;
using BiddingManagementSystem.Domain.Entities;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders
{
    public record GetOpenTendersQuery() : IRequest<IEnumerable<Tender>>;

    public class GetOpenTendersHandler : IRequestHandler<GetOpenTendersQuery, IEnumerable<Tender>>
    {
        private readonly ITenderRepository _repository;

        public GetOpenTendersHandler(ITenderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tender>> Handle(GetOpenTendersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetOpenTendersAsync();
        }
    }
}
