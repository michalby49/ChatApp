using ChatApp.Core.Models;
using ChatApp.Data.Repositories.Interfaces;
using MediatR;

namespace ChatApp.Core.Commands.Handlers
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, Unit>
    {
        private readonly IMessageRepository _messageRepository;

        public SendMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Unit> Handle(SendMessageCommand command, CancellationToken cancellationToken)
        {
            var message = new Message
            {
                Id = Guid.NewGuid(),
                InboxId = command.InboxId,
                SenderId = command.SenderId,
                Content = command.Content,
                SentAt = DateTime.UtcNow
            };

            await _messageRepository.AddMessageAsync(message);

            return Unit.Value;
        }
    }
}