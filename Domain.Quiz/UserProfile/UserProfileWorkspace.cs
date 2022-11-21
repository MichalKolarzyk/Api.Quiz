using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.UserProfile
{
    public class UserProfileWorkspace
    {
        public string Name { get; set; } = string.Empty;
        public Guid WorkspaceId { get; set; }
    }
}
