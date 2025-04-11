// Domain/Entities/Tender.cs
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.ValueObjects;
using System;
using System.Security.Cryptography;

namespace BiddingManagementSystem.Domain.Entities
{
    public class Tender
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Deadline { get; private set; }
        public Money Budget { get; private set; }
        public string Category { get; private set; }
        public string Type { get; private set; }
        public string Location { get; private set; }
        public TenderStatus Status { get; private set; } = TenderStatus.Draft;
        public ICollection<Bid> Bids { get; private set; } = new List<Bid>();

        private Tender() { } // For EF

        public Tender(string title, string description, DateTime deadline, Money budget, string category, string type, string location)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            Budget = budget;
            Category = category;
            Type = type;
            Location = location;
            Status = TenderStatus.Open;
        }

        public void CloseTender()
        {
            Status = TenderStatus.Closed;
        }

        public void AwardTender()
        {
            Status = TenderStatus.Awarded;
        }
    }
}
