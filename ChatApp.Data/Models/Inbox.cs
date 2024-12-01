using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core.Models
{
    public class Inbox
    {
        public DateTime CreatedAt { get; set; }

        public Guid Id { get; set; }

        // Lista wiadomości w skrzynce
        public ICollection<Message> Messages { get; set; } = new List<Message>();

        public string Name { get; set; } // Opcjonalna nazwa inboxa (np. nazwa grupy)

        // Lista użytkowników wchodzących w skład tego inboxa
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}