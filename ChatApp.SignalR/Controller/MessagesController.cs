using ChatApp.Core.Commands;
using ChatApp.Core.Models;
using ChatApp.Core.Queries;
using ChatApp.Data.DbContexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{inboxId}")]
    public async Task<IActionResult> GetMessagesByInbox(Guid inboxId)
    {
        var query = new GetMessagesByInboxQuery { InboxId = inboxId };
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