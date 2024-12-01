using ChatApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);

        Task<User> GetUserByIdAsync(Guid userId);

        Task<IEnumerable<User>> GetUsersByIdsAsync(IEnumerable<Guid> userIds);
    }
}