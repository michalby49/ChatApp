using ChatApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Data.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task AddMessageAsync(Message message);

        Task<IEnumerable<Message>> GetMessagesByInboxIdAsync(Guid inboxId);
    }
}