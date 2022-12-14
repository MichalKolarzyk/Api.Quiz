using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Workspaces.DomainEvents
{
    public class CreateWorkspaceDomainEvent : DomainEvent
    {
        public string Name { get; set; } = string.Empty;
        public Guid OwnerUserProfileId { get; set; }
        public Guid WorkspaceId { get; set; }
    }
}
