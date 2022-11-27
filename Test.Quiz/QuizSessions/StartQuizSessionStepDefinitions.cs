using Domain.Quiz.QuizSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Quiz.QuizSessions
{
    [Binding, Scope(Feature = "StartQuizSession")]
    public class StartQuizSessionStepDefinitions
    {
        private QuizSessionAggregate? _quizSession;
        private DateTime _orginalActualStartData;

        [Given("The session is created")]
        public void TheSessionIsCreated()
        {
            _quizSession = new QuizSessionAggregate(Guid.NewGuid(), 
                Guid.NewGuid(), 
                DateTime.Now, 
                30, 
                10, 
                QuizSessionAggregate.PickQuestionType.OneByOne);

            _orginalActualStartData = _quizSession.ActualStartTime;
        }

        [When("Session is started")]
        public void SessionIsStarted()
        {
            _quizSession?.Start();
        }

        [Then("Quiz Session should change status to Started")]
        public void QuizSessionShouldChangeStatusToStarted()
        {
            _quizSession?.QuizState.Should().Be(QuizSessionAggregate.State.Started);
        }

        [Then("Quiz Session should change actual start time")]
        public void QuizSessionShouldChangeActualStartTime()
        {
            _quizSession?.ActualStartTime.Should().NotBe(_orginalActualStartData);
        }
    }
}
