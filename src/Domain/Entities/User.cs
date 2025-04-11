// Domain/Entities/User.cs
using BiddingManagementSystem.Domain.Enums;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BiddingManagementSystem.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; }
        public ICollection<Bid> Bids { get; private set; } = new List<Bid>();

        private User() { } // For EF

        public User(string fullName, string email, string passwordHash, UserRole role)
        {
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
