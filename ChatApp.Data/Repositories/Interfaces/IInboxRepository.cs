using ChatApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Data.Repositories.Interfaces
{
    public interface IInboxRepository
    {
        Task AddInboxAsync(Inbox inbox);

        Task<Inbox> GetInboxByIdAsync(Guid inboxId);

        Task<IEnumerable<Inbox>> GetInboxesByUserIdAsync(Guid userId);

        Task<Inbox> GetInboxWithUsersAsync(Guid inboxId);
    }
}