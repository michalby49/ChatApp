using ChatApp.Core.Models;
using ChatApp.Data.Repositories.Interfaces;
using MediatR;

namespace ChatApp.Core.Queries.Handlers
{
    public class GetInboxesByUserQueryHandler : IRequestHandler<GetInboxesByUserQuery, IEnumerable<Inbox>>
    {
        private readonly IInboxRepository _inboxRepository;

        public GetInboxesByUserQueryHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository;
        }

        public async Task<IEnumerable<Inbox>> Handle(GetInboxesByUserQuery query, CancellationToken cancellationToken)
        {
            return await _inboxRepository.GetInboxesByUserIdAsync(query.UserId);
        }
    }
}