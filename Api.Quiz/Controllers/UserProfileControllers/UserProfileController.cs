using Api.Quiz.Services;
using Application.Quiz.Database;
using Domain.Quiz.UserProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Quiz.Controllers.UserProfileControllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly HttpContextService _contextService;
        private readonly IRepository<UserProfileAggregate> _repository;

        public UserProfileController(HttpContextService contextService, IRepository<UserProfileAggregate> repository)
        {
            _contextService = contextService;
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserProfileAggregate>> Get()
        {
            var userProfileId = _contextService.GetAccountId();

            var userProfile = await _repository.GetOne(u => u.AccountId == userProfileId);

            return userProfile;
        }

    }
}
