// Application/Features/Tenders/CreateTenderCommand.cs
using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Domain.Contracts;
using BiddingManagementSystem.Domain.Entities;
using BiddingManagementSystem.Domain.ValueObjects;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders
{
    public record CreateTenderCommand(CreateTenderDto Dto) : IRequest<Guid>;

    public class CreateTenderHandler : IRequestHandler<CreateTenderCommand, Guid>
    {
        private readonly ITenderRepository _repository;

        public CreateTenderHandler(ITenderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateTenderCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var tender = new Tender(
                dto.Title,
                dto.Description,
                dto.Deadline,
                new Money(dto.BudgetAmount, dto.BudgetCurrency),
                dto.Category,
                dto.Type,
                dto.Location
            );

            await _repository.AddAsync(tender);
            await _repository.SaveChangesAsync();

            return tender.Id;
        }
    }
}
