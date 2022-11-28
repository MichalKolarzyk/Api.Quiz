using Domain.Quiz.QuizSession;
using Domain.Quiz.Quizzes;
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
        }

        [Then]
        public void TheSessionStateShouldBeReady()
        {
            _quizSession?.QuizState.Should().Be(QuizSessionAggregate.State.Ready);
        }
    }
}
