using Domain.Quiz.Abstracts;
using Domain.Quiz.Workspaces.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Workspaces
{

    public class WorkspaceAggregate : AggregateRoot
    {
        public WorkspaceAggregate(string name, Guid ownerUserProfileId, WorkspaceType type)
        {
            Name = name;
            OwnerUserProfileId = ownerUserProfileId;
            Type = type;
            Id = Guid.NewGuid();

            AddDomainEvent(new CreateWorkspaceDomainEvent
            {
                Name = name,
                OwnerUserProfileId = ownerUserProfileId,
                WorkspaceId = Id,
            });
        }

        public enum WorkspaceType
        {
            Private,
            Public,
        }
        public string Name { get; set; } = string.Empty;

        public Guid OwnerUserProfileId { get; set; }

        public WorkspaceType Type { get; set; }

        public List<Guid> AdditionalOwners { get; set; } = new();
    }
}
