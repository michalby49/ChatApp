﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core.Models
{
    public class Message
    {
        public string Content { get; set; }

        public Guid Id { get; set; }

        public Inbox Inbox { get; set; }

        public Guid InboxId { get; set; }

        public User Sender { get; set; }

        public Guid SenderId { get; set; }

        public DateTime SentAt { get; set; }
    }
}