using Application.Quiz.Database;
using Application.Quiz.ReferenceItems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Quiz.Controllers.ReferenceItemComtrollers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReferenceItemController : ControllerBase
    {
        private readonly IRepository<ReferenceItem> _repository;

        public ReferenceItemController(IRepository<ReferenceItem> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<ReferenceItem>> Get([FromQuery] string key)
        {
            return await _repository.GetListAsync(i => i.Key == key);
        }
    }
}
