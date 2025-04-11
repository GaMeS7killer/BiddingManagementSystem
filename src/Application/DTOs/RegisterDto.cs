// Application/DTOs/RegisterDto.cs
namespace BiddingManagementSystem.Application.DTOs
{
    public class RegisterDto
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = default!; // e.g., "Bidder", "Evaluator", "ProcurementOfficer"
    }
}

// Application/DTOs/LoginDto.cs
namespace BiddingManagementSystem.Application.DTOs
{
    public class LoginDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
