using ChatApp.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core.Queries
{
    public class GetMessagesByInboxQuery : IRequest<IEnumerable<Message>>
    {
        public Guid InboxId { get; set; }
    }
}