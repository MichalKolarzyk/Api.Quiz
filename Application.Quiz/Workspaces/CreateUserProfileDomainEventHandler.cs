using Application.Quiz.Database;
using Domain.Quiz.UserProfile;
using Domain.Quiz.Workspaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Workspaces
{
    internal class CreateUserProfileDomainEventHandler : INotificationHandler<CreateUserProfileDomainEvent>
    {
        private readonly IRepository<WorkspaceAggregate> _workspaceRepository;

        public CreateUserProfileDomainEventHandler(IRepository<WorkspaceAggregate> workspaceRepository)
        {
            _workspaceRepository = workspaceRepository;
        }

        public async Task Handle(CreateUserProfileDomainEvent notification, CancellationToken cancellationToken)
        {
            var workspace = new WorkspaceAggregate
            {
                Name = "new workspace",
                OwnerUserProfileId = notification.UserProfileId,
                Type = WorkspaceAggregate.WorkspaceType.Private,
            };
            await _workspaceRepository.InsertOne(workspace);
        }
    }
}
