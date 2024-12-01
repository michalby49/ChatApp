using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core.Commands
{
    public class CreateInboxCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public List<Guid> UserIds { get; set; }
    }
}