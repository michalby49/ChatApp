using ChatApp.Core.Models;
using ChatApp.Data.Repositories.Interfaces;
using MediatR;

namespace ChatApp.Core.Queries.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}