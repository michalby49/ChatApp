namespace ChatApp.Core.Models
{
    public class User
    {
        public DateTime CreatedAt { get; set; }

        public Guid Id { get; set; }

        public ICollection<Inbox> Inboxes { get; set; } = new List<Inbox>();

        public string PasswordHash { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Username { get; set; }
    }
}