using ChatApp.Core.Models;
using MediatR;

namespace ChatApp.Core.Queries
{
    public class GetInboxesByUserQuery : IRequest<IEnumerable<Inbox>>
    {
        public Guid UserId { get; set; }
    }
}