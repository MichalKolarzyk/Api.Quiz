namespace Api.Quiz.Controllers.QuizControllers
{
    public class UpdateQuizBody
    {
        public List<Guid> QuestionIds { get; set; } = new List<Guid>();
    }
}
