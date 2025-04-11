// Application/DTOs/BidDto.cs
namespace BiddingManagementSystem.Application.DTOs
{
    public class BidDto
    {
        public Guid TenderId { get; set; }
        public Guid UserId { get; set; } // Normally extracted from JWT in real apps
        public decimal Price { get; set; }
        public string Description { get; set; } = default!;
    }
}
