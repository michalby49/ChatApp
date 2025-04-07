using Microsoft.AspNetCore.Identity;

namespace ChatApp.Core.Models
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }

        public ICollection<Inbox> Inboxes { get; set; } = new List<Inbox>();
    }
}