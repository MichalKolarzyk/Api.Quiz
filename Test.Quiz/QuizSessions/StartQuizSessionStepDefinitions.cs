using Domain.Quiz.QuizSession;
using Domain.Quiz.Quizzes;
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

        [Given]
        public void TheSessionIsCreated()
        {
            var quiz = new QuizAggregate(Guid.NewGuid(), Guid.NewGuid());
            quiz.QuestionIds.Add(Guid.NewGuid());

            _quizSession = new QuizSessionAggregate(quiz, 
                Guid.NewGuid(), 
                DateTime.Now, 
                30, 
                10, 
                QuizSessionAggregate.PickQuestionType.OneByOne);

            _orginalActualStartData = _quizSession.ActualStartTime;
        }

        [When]
        public void SessionIsStarted()
        {
            _quizSession?.Start();
        }

        [Then]
        public void QuizSessionShouldChangeStatusToStarted()
        {
            _quizSession?.QuizState.Should().Be(QuizSessionAggregate.State.Started);
        }

        [Then]
        public void QuizSessionShouldChangeActualStartTime()
        {
            _quizSession?.ActualStartTime.Should().NotBe(_orginalActualStartData);
        }
    }
}
