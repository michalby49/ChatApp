using MediatR;

namespace ChatApp.Core.Queries
{
    public class LoginUserQuery : IRequest<string> // Zwraca token JWT
    {
        public string Password { get; set; }

        public string UserName { get; set; }
    }
}