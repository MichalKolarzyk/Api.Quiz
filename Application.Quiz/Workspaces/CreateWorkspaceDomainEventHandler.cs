using Application.Quiz.Database;
using Domain.Quiz.UserProfile;
using Domain.Quiz.Workspaces;
using Domain.Quiz.Workspaces.DomainEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Workspaces
{
    internal class CreateWorkspaceDomainEventHandler : INotificationHandler<CreateWorkspaceDomainEvent>
    {
        private readonly IRepository<UserProfileAggregate> _userProfileWorkspace;

        public CreateWorkspaceDomainEventHandler(IRepository<UserProfileAggregate> userProfileWorkspace)
        {
            _userProfileWorkspace = userProfileWorkspace;
        }

        public async Task Handle(CreateWorkspaceDomainEvent notification, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileWorkspace.GetOne(p => p.Id == notification.OwnerUserProfileId);
            userProfile.AddWorkspace(new UserProfileWorkspace
            {
                Name = notification.Name,
                WorkspaceId = notification.WorkspaceId,
            });

            await _userProfileWorkspace.ReplaceOne(userProfile);
        }
    }
}
