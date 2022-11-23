namespace Api.Quiz.Controllers.QuizControllers
{
    public class UpdateQuizDto
    {
        public List<Guid> QuestionIds { get; set; } = new List<Guid>();
    }
}
