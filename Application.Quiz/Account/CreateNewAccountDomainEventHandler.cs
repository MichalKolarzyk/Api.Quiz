using Application.Quiz.Database;
using Domain.Quiz.Account;
using Domain.Quiz.Workspaces;
using MediatR;

namespace Application.Quiz.Account
{
    public class CreateNewAccountDomainEventHandler : INotificationHandler<CreateNewAccountDomainEvent>
    {
        private readonly IRepository<Workspace> _repository;

        public CreateNewAccountDomainEventHandler(IRepository<Workspace> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateNewAccountDomainEvent notification, CancellationToken cancellationToken)
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
