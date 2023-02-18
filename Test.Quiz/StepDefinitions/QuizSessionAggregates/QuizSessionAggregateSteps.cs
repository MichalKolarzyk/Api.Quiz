using Domain.Quiz.QuizSession;
using Domain.Quiz.Quizzes;

namespace Test.Quiz.StepDefinitions.QuizSessionAggregates
{
    [Binding, Scope(Tag = "QuizSessionAggregates")]
    public class QuizSessionAggregateSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public QuizSessionAggregateSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given]
        public void TheSessionIsCreated()
        {
            var quiz = new QuizAggregate(Guid.NewGuid(), Guid.NewGuid());
            quiz.QuestionIds.Add(Guid.NewGuid());

            var quizSession = new QuizSessionAggregate(quiz,
                Guid.NewGuid(),
                DateTime.Now,
                30,
                10,
                QuizSessionAggregate.PickQuestionType.OneByOne);

            _scenarioContext.Set(quizSession);
        }

        [Given(@"The session is created with start date (.*), with question amount (.*), with time for each question (.*)")]
        public void TheSessionIsCreatedWithParameters(DateTime startDate, int questionAmount, int timeForEachQuestion)
        {
            var quiz = new QuizAggregate(Guid.NewGuid(), Guid.NewGuid());
            quiz.QuestionIds.Add(Guid.NewGuid());

            var quizSession = new QuizSessionAggregate(quiz,
                Guid.NewGuid(),
                startDate,
                timeForEachQuestion,
                questionAmount,
                QuizSessionAggregate.PickQuestionType.OneByOne);

            _scenarioContext.Set(quizSession);
        }

        [Then(@"The quiz session should have (.*) State")]
        public void TheSessionStateShouldBe(QuizSessionAggregate.State state)
        {
            var quizSession = _scenarioContext.Get<QuizSessionAggregate>();
            quizSession?.QuizState.Should().Be(state);
        }

        [Then(@"The quiz session should have (.*) Start time")]
        public void TheSessionStartDateshouldBe(DateTime startDate)
        {
            var quizSession = _scenarioContext.Get<QuizSessionAggregate>();
            quizSession.StartTime.Should().Be(startDate);
        }

        [When]
        public void SessionIsStarted()
        {
            var quizSession = _scenarioContext.Get<QuizSessionAggregate>();
            quizSession.Start();
        }

        [When]
        public void NextQuestionIsStarted()
        {
            var quizSession = _scenarioContext.Get<QuizSessionAggregate>();
            quizSession.StartNextQuestion();
        }

        [When]
        public void CurrentQuestionIsFinished()
        {
            var quizSession = _scenarioContext.Get<QuizSessionAggregate>();
            quizSession.FinishCurrentQuestion();
        }

    }
}
