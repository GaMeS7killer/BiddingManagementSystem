// Application/Validators/CreateTenderValidator.cs
using BiddingManagementSystem.Application.DTOs;
using FluentValidation;

namespace BiddingManagementSystem.Application.Validators
{
    public class CreateTenderValidator : AbstractValidator<CreateTenderDto>
    {
        public CreateTenderValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Deadline).GreaterThan(DateTime.UtcNow);
            RuleFor(x => x.BudgetAmount).GreaterThan(0);
            RuleFor(x => x.BudgetCurrency).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
        }
    }
}
