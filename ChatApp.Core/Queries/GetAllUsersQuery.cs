using ChatApp.Core.Models;
using MediatR;

namespace ChatApp.Core.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}