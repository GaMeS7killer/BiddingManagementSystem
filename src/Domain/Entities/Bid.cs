// Domain/Entities/Bid.cs
using System;

namespace BiddingManagementSystem.Domain.Entities
{
    public class Bid
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid TenderId { get; private set; }
        public Guid UserId { get; private set; }

        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public DateTime SubmittedAt { get; private set; } = DateTime.UtcNow;
        public bool IsWinner { get; private set; }

        public Tender Tender { get; private set; }
        public User User { get; private set; }

        private Bid() { }

        public Bid(Guid tenderId, Guid userId, decimal price, string description)
        {
            TenderId = tenderId;
            UserId = userId;
            Price = price;
            Description = description;
            SubmittedAt = DateTime.UtcNow;
        }

        public void MarkAsWinner()
        {
            IsWinner = true;
        }
    }
}
