// API/Controllers/BidsController.cs
using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Features.Bids;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BidsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Bidder")]
        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] BidDto dto)
        {
            var command = new SubmitBidCommand(dto);
            var bidId = await _mediator.Send(command);
            return Ok(new { BidId = bidId });
        }
    }
}
