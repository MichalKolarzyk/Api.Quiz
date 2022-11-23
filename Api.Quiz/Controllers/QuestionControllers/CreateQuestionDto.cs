namespace Api.Quiz.Controllers.QuestionControllers
{
    public class CreateQuestionDto
    {
        public Guid WorkspaceId { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<string> Answers { get; set; } = new List<string>();

        public int CorrectAnswerIndex { get; set; }

        public int TimeoutInSeconds { get; set; }
    }
}
