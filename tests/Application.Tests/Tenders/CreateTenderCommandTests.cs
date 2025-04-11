// tests/Application.Tests/Tenders/CreateTenderCommandTests.cs
using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Features.Tenders;
using BiddingManagementSystem.Domain.Contracts;
using BiddingManagementSystem.Domain.Entities;
using BiddingManagementSystem.Domain.ValueObjects;
using Moq;
using Xunit;

namespace Application.Tests.Tenders
{
    public class CreateTenderCommandTests
    {
        [Fact]
        public async Task Handle_ShouldReturnTenderId_WhenValid()
        {
            // Arrange
            var mockRepo = new Mock<ITenderRepository>();
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Tender>())).Returns(Task.CompletedTask);
            mockRepo.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            var handler = new CreateTenderHandler(mockRepo.Object);

            var dto = new CreateTenderDto
            {
                Title = "Test Tender",
                Description = "Desc",
                Deadline = DateTime.UtcNow.AddDays(5),
                BudgetAmount = 1000,
                BudgetCurrency = "USD",
                Category = "IT",
                Type = "Open",
                Location = "Amman"
            };

            // Act
            var result = await handler.Handle(new CreateTenderCommand(dto), default);

            // Assert
            Assert.IsType<Guid>(result);
        }
    }
}
