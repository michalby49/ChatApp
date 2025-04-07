using ChatApp.Core.Commands;
using ChatApp.Core.Models;
using ChatApp.Core.Queries;
using ChatApp.Data.DbContexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CoreController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateInbox([FromBody] CreateInboxCommand command)
    {
        await _mediator.Send(command);
        return Ok(command);
    }

    [HttpGet("messages/{inboxId}")]
    public async Task<IActionResult> GetMessagesByInbox(Guid inboxId)
    {
        var query = new GetMessagesByInboxQuery { InboxId = inboxId };
        var messages = await _mediator.Send(query);
        return Ok(messages);
    }

    [HttpGet("inboxes/{userId}")]
    public async Task<IActionResult> GetUserInboxes(Guid userId)
    {
        var query = new GetInboxesByUserQuery { UserId = userId };
        var messages = await _mediator.Send(query);
        return Ok(messages);
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageCommand command)
    {
        await _mediator.Send(command);
        return Ok(command);
    }
}