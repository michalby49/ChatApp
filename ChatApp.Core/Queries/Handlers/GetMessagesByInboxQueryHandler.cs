using ChatApp.Core.Models;
using ChatApp.Data.Repositories.Interfaces;
using MediatR;

namespace ChatApp.Core.Queries.Handlers
{
    public class GetMessagesByInboxQueryHandler : IRequestHandler<GetMessagesByInboxQuery, IEnumerable<Message>>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessagesByInboxQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Message>> Handle(GetMessagesByInboxQuery query, CancellationToken cancellationToken)
        {
            return await _messageRepository.GetMessagesByInboxIdAsync(query.InboxId);
        }
    }
}