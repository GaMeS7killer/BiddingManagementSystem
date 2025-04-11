// API/Controllers/TendersController.cs
using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Features.Tenders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TendersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TendersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "ProcurementOfficer")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTenderDto dto)
        {
            var command = new CreateTenderCommand(dto);
            var tenderId = await _mediator.Send(command);
            return Ok(new { TenderId = tenderId });
        }

        [AllowAnonymous]
        [HttpGet("open")]
        public async Task<IActionResult> GetOpen()
        {
            var tenders = await _mediator.Send(new GetOpenTendersQuery());
            return Ok(tenders);
        }

        // In TendersController.cs
        [Authorize(Roles = "Evaluator")]
        [HttpPost("{tenderId}/evaluate")]
        public async Task<IActionResult> Evaluate(Guid tenderId)
        {
            var result = await _mediator.Send(new EvaluateBidsCommand(tenderId));
            return Ok(new { Message = result });
        }

    }
}
