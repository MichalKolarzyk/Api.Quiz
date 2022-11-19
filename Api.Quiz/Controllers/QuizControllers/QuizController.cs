using Domain.Quiz.Quizzes;
using FluentValidation;
using Infrastructure.Quiz.Databases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Quiz.Controllers.QuizControllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateQuizCommand> _createQuizCommandValidator;

        public QuizController(IMediator mediator, IValidator<CreateQuizCommand> createQuizCommandValidator)
        {
            _mediator = mediator;
            _createQuizCommandValidator = createQuizCommandValidator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand createQuizCommand)
        {
            _createQuizCommandValidator.Validate(createQuizCommand, options => options.ThrowOnFailures());

            var createdQuiz = await _mediator.Send(createQuizCommand);
            return Ok(createdQuiz.Id);
        }

        [HttpPost("{quizId}/addQuestion")]
        public async Task<IActionResult> AddQuestion([FromRoute] Guid quizId, [FromBody] AddQuestion addQuestion)
        {
            await _mediator.Send(new AddQuestionCommand
            {
                QuizId = quizId,
                Answers = addQuestion.Answers,
                CorrectAnswerIndex = addQuestion.CorrectAnswerIndex,
                Description = addQuestion.Description,
                TimeoutInSeconds = addQuestion.TimeoutInSeconds,

            });
            return Ok();
        }
    }
}
