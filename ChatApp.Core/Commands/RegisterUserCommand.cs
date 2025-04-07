using MediatR;

namespace ChatApp.Core.Commands
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}