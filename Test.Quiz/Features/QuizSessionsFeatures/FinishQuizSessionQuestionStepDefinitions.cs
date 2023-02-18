using Domain.Quiz.QuizSession;
using Domain.Quiz.Quizzes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Quiz.Features.QuizSessionsFeatures
{
    [Binding, Scope(Feature = "FinishQuizSessionQuestion")]
    public class FinishQuizSessionQuestionStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public FinishQuizSessionQuestionStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("The session is created with (.*) questions")]
        public void TheSessionIsCreated(int number)
        {
            var quiz = new QuizAggregate(Guid.NewGuid(), Guid.NewGuid());

            for (int i = 0; i < number; i++)
                quiz.QuestionIds.Add(Guid.NewGuid());

            var quizSession = new QuizSessionAggregate(quiz,
                Guid.NewGuid(),
                DateTime.Now,
                30,
                number,
                QuizSessionAggregate.PickQuestionType.OneByOne);

            _scenarioContext.Set(quizSession);
        }
    }
}
