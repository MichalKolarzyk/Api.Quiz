using Application.Quiz.Questions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Quiz.Controllers.QuestionControllers
{
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
        public async Task<IActionResult> Create([FromBody] CreateQuestionDto createQuestion)
        {
            await _mediator.Send(new CreateQuestionCommand
            {
                WorkspaceId = createQuestion.WorkspaceId,
                Answers = createQuestion.Answers,
                CorrectAnswerIndex = createQuestion.CorrectAnswerIndex,
                Description = createQuestion.Description,
            });

            return Ok();
        }
    }
}
