using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Workspaces
{
    public class Workspace : AggregateRoot
    {
        public enum WorkspaceType
        {
            Private,
            Public,
        }
        public string Name { get; set; } = string.Empty;

        public Guid OwnerUserId { get; set; }

        public List<Guid> UserIds { get; set; } = new();

        public List<Guid> QuizIds { get; set; } = new();

        public WorkspaceType Type { get; set; }
    }
}
