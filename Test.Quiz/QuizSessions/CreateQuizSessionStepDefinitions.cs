using Domain.Quiz.QuizSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Quiz.QuizSessions
{
    [Binding, Scope(Feature = "CreateQuizSession")]
    public class CreateQuizSessionStepDefinitions
    {
        private QuizSessionAggregate? _quizSession;

        [Given("The session is created")]
        public void TheSessionIsCreated()
        {
            _quizSession = new QuizSessionAggregate(Guid.NewGuid(),
                Guid.NewGuid(),
                DateTime.Now,
                30,
                10,
                QuizSessionAggregate.PickQuestionType.OneByOne);
        }

        [Then("The session state should be Ready")]
        public void TheSessionStateShouldBeReady()
        {
            _quizSession?.QuizState.Should().Be(QuizSessionAggregate.State.Ready);
        }
    }
}
