using Application.Quiz.Aggregations;
using Application.Quiz.Database;
using Application.Quiz.Questions.CreateQuestion;
using Application.Quiz.Questions.GetQuestion;
using Application.Quiz.Questions.GetQuestions;
using Application.Quiz.Questions.UpdateQuestion;
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

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<GetQuestionResponse> GetById([FromRoute] Guid id)
        {
            return await _mediator.Send(new GetQuestionRequest(id));
        }

        [HttpPost]
        public async Task<GetQuestionsResponse> Get([FromBody] GetQuestionsCommand getQuestionCommand)
        {
            return await _mediator.Send(getQuestionCommand);
        }
    }
}
