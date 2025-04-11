// Application/DTOs/CreateTenderDto.cs
namespace BiddingManagementSystem.Application.DTOs
{
    public class CreateTenderDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime Deadline { get; set; }
        public decimal BudgetAmount { get; set; }
        public string BudgetCurrency { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Location { get; set; } = default!;
    }
}
