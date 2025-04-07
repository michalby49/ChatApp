using ChatApp.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Core.Commands.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            IdentityResult result;
            try
            {
                var user = new User
                {
                    UserName = request.UserName,
                    Email = request.Email
                };

                result = await _userManager.CreateAsync(user, request.Password);
            }
            catch (Exception)
            {

                throw;
            }

            return result.Succeeded;
        }
    }
}