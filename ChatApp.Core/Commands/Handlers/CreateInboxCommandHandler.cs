using ChatApp.Core.Models;
using ChatApp.Data.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core.Commands.Handlers
{
    public class CreateInboxCommandHandler : IRequestHandler<CreateInboxCommand, Unit>
    {
        private readonly IInboxRepository _inboxRepository;
        private readonly IUserRepository _userRepository;

        public CreateInboxCommandHandler(IInboxRepository inboxRepository, IUserRepository userRepository)
        {
            _inboxRepository = inboxRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateInboxCommand command, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersByIdsAsync(command.UserIds);

            var inbox = new Inbox
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                CreatedAt = DateTime.UtcNow,
                Users = users.ToList()
            };

            await _inboxRepository.AddInboxAsync(inbox);

            return Unit.Value;
        }
    }
}