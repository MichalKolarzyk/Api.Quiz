using Application.Quiz.Database;
using Domain.Quiz.Account;
using Domain.Quiz.UserProfile;
using Domain.Quiz.Workspaces;
using MediatR;

namespace Application.Quiz.UserProfiles
{
    public class CreateNewAccountDomainEventHandler : INotificationHandler<CreateNewAccountDomainEvent>
    {
        private readonly IRepository<UserProfileAggregate> _userProfileRepository;

        public CreateNewAccountDomainEventHandler(IRepository<UserProfileAggregate> userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task Handle(CreateNewAccountDomainEvent notification, CancellationToken cancellationToken)
        {
            var userProfile = new UserProfileAggregate(notification.AccountId);
            await _userProfileRepository.InsertOne(userProfile);
            await _userProfileRepository.Save();
        }
    }
}
