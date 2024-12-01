using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Core.Models;

namespace ChatApp.Data.DbContexts
{
    public class ChatAppDbContext : DbContext
    {
        public ChatAppDbContext() : base(new DbContextOptions<ChatAppDbContext>())
        {
        }

        public DbSet<Inbox> Inboxes { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<User> Users { get; set; }

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