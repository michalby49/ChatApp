using ChatApp.Core.Models;
using ChatApp.Data.DbContexts;
using ChatApp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Data.Repositories
{
    public class InboxRepository : IInboxRepository
    {
        private readonly ChatAppDbContext _context;

        public InboxRepository(ChatAppDbContext context)
        {
            _context = context;
        }

        public async Task AddInboxAsync(Inbox inbox)
        {
            await _context.Inboxes.AddAsync(inbox);
            await _context.SaveChangesAsync();
        }

        public async Task<Inbox> GetInboxByIdAsync(Guid inboxId)
        {
            return await _context.Inboxes.FindAsync(inboxId);
        }

        public async Task<IEnumerable<Inbox>> GetInboxesByUserIdAsync(Guid userId)
        {
            return await _context.Inboxes.Where(i => i.Users.Any(u => u.Id == userId)).ToListAsync();
        }

        public async Task<Inbox> GetInboxWithUsersAsync(Guid inboxId)
        {
            return await _context.Inboxes.Include(i => i.Users)
                                         .Include(i => i.Messages)
                                         .FirstOrDefaultAsync(i => i.Id == inboxId);
        }
    }
}