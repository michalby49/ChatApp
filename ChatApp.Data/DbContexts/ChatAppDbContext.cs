using Microsoft.EntityFrameworkCore;
using ChatApp.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ChatApp.Data.DbContexts
{
    public class ChatAppDbContext : IdentityDbContext<User>
    {
        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)
        {
        }

        public DbSet<Inbox> Inboxes { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ChatAppDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja relacji wiele-do-wielu dla Inbox <-> Users
            modelBuilder.Entity<Inbox>()
                .HasMany(i => i.Users)
                .WithMany(u => u.Inboxes)
                .UsingEntity(join => join.ToTable("UserInboxes"));
        }
    }
}