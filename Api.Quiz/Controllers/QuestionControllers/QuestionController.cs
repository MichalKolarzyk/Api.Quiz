using Application.Quiz.Database;
using Application.Quiz.Questions;
using Application.Quiz.Services;
using Domain.Quiz.Questions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Quiz.Controllers.QuestionControllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Question> _questionRepository;
        private readonly ICurrentIdentity _currentIdentity;

        public QuestionController(IMediator mediator, IRepository<Question> questionRepository, ICurrentIdentity currentIdentity)
        {
            _mediator = mediator;
            _questionRepository = questionRepository;
            _currentIdentity = currentIdentity;
        }

        [HttpPost("create")]
        public async Task<CreateQuestionResponse> Create([FromBody] CreateQuestionCommand createQuestionCommand)
        {
            return await _mediator.Send(createQuestionCommand);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateQuestionCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<QuestionDto> GetById([FromRoute] string id)
        {
            var question = await _questionRepository.GetAsync(q => q.Id == new Guid(id));
            return new QuestionDto()
            {
                Id = question.Id,
                Answers = question.Answers,
                Author = "",
                Category = question.Category,
                CorrectAnswerIndex = question.CorrectAnswerIndex,
                DefaultLanugage = question.DefaultLanugage,
                Description = question.Description,
                IsPrivate = question.IsPrivate,
                CanUserEdit = _currentIdentity.AccountId == question.AuthorId
            };
        }

        [HttpPost]
        public async Task<GetQuestionsResponse> Get([FromBody] FilterQuestionsCommand getQuestionCommand)
        {
            return await _mediator.Send(getQuestionCommand);
        }
    }
}
