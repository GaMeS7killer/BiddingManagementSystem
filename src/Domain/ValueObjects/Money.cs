// Domain/ValueObjects/Money.cs
using System;

namespace BiddingManagementSystem.Domain.ValueObjects
{
    public record Money
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0)
                throw new ArgumentException("Amount must be positive");
            Amount = amount;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public override string ToString() => $"{Amount} {Currency}";
    }
}
