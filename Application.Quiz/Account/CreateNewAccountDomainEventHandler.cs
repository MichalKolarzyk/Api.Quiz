using Application.Quiz.Database;
using Domain.Quiz.Account;
using Domain.Quiz.UserProfile;
using Domain.Quiz.Workspaces;
using MediatR;

namespace Application.Quiz.Account
{
    public class CreateNewAccountDomainEventHandler : INotificationHandler<CreateNewAccountDomainEvent>
    {
        private readonly IRepository<UserProfileAggregate> _userProfileRepository;
        private readonly IRepository<WorkspaceAggregate> _workspaceRepository;

        public CreateNewAccountDomainEventHandler(IRepository<UserProfileAggregate> userProfileRepository, IRepository<WorkspaceAggregate> workspaceRepository)
        {
            _userProfileRepository = userProfileRepository;
            _workspaceRepository = workspaceRepository;
        }

        public async Task Handle(CreateNewAccountDomainEvent notification, CancellationToken cancellationToken)
        {
            var userProfile = new UserProfileAggregate(notification.AccountId, notification.Login);
            await _userProfileRepository.InsertOne(userProfile);

            var workspace = new WorkspaceAggregate("New aggregate", userProfile.Id, WorkspaceAggregate.WorkspaceType.Private);
            await _workspaceRepository.InsertOne(workspace);
        }
    }
}
