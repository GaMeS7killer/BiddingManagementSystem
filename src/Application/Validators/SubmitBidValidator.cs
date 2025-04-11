// Application/Validators/SubmitBidValidator.cs
using BiddingManagementSystem.Application.DTOs;
using FluentValidation;

namespace BiddingManagementSystem.Application.Validators
{
    public class SubmitBidValidator : AbstractValidator<BidDto>
    {
        public SubmitBidValidator()
        {
            RuleFor(x => x.TenderId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        }
    }
}
