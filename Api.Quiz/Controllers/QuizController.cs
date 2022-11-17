using Domain.Quiz.Quizzes;
using Infrastructure.Quiz.Databases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Quiz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;


        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand createQuizCommand)
        {
            var createdQuiz = await _mediator.Send(createQuizCommand);
            return Ok(createdQuiz.Id);
        }

        [HttpPost("{quizId}/addQuestion")]
        public async Task<IActionResult> AddQuestion([FromRoute] Guid quizId, [FromBody] AddQuestionCommand addQuestionCommand)
        {
            return Ok();
        }
    }
}
