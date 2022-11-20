using Domain.Quiz.Workspaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.UserProfile
{
    public class GetUserProfileResponse
    {
        public Guid AccountId { get; set; }
        public List<WorkspaceAggregate> Workspaces { get; set; } = new List<WorkspaceAggregate>();
    }
}
