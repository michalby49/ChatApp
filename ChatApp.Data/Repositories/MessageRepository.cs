using ChatApp.Core.Models;
using ChatApp.Data.DbContexts;
using ChatApp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatAppDbContext _context;

        public MessageRepository(ChatAppDbContext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesByInboxIdAsync(Guid inboxId)
        {
            return await _context.Messages.Where(m => m.InboxId == inboxId)
                                          .OrderBy(m => m.SentAt)
                                          .ToListAsync();
        }
    }
}