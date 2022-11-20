using Application.Quiz.Database;
using Domain.Quiz.Users;
using Domain.Quiz.Workspaces;
using MediatR;

namespace Application.Quiz.Users
{
    public class CreateNewUserDomainEventHandler : INotificationHandler<CreateNewUserDomainEvent>
    {
        private readonly IRepository<Workspace> _repository;

        public CreateNewUserDomainEventHandler(IRepository<Workspace> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateNewUserDomainEvent notification, CancellationToken cancellationToken)
        {
            var workspace = new Workspace
            {
                Name = "new workspace",
                OwnerUserId = notification.UserId,
                Type = Workspace.WorkspaceType.Private,
            };

            await _repository.InsertOne(workspace);
        }
    }
}
