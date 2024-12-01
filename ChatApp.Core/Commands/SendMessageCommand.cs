﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core.Commands
{
    public class SendMessageCommand : IRequest<Unit>
    {
        public string Content { get; set; }

        public Guid InboxId { get; set; }

        public Guid SenderId { get; set; }
    }
}