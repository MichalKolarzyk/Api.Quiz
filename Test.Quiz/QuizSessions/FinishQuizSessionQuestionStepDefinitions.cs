using Domain.Quiz.QuizSession;
using Domain.Quiz.Quizzes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Quiz.QuizSessions
{
    [Binding, Scope(Feature = "FinishQuizSessionQuestion")]
    public class FinishQuizSessionQuestionStepDefinitions
    {
        private QuizSessionAggregate? _quizSession;

        [Given("The session is created with (.*) questions")]
        public void TheSessionIsCreated(int number)
        {
            var quiz = new QuizAggregate(Guid.NewGuid(), Guid.NewGuid());

            for(int i = 0; i < number; i++)
                quiz.QuestionIds.Add(Guid.NewGuid());

            _quizSession = new QuizSessionAggregate(quiz, 
                Guid.NewGuid(), 
                DateTime.Now, 
                30,
                number, 
                QuizSessionAggregate.PickQuestionType.OneByOne);
        }

        [When]
        public void SessionIsStarted()
        {
            _quizSession?.Start();
        }

        [When]
        public void NextQuestionIsStarted()
        {
            _quizSession?.StartNextQuestion();
        }

        [When]
        public void CurrentQuestionIsFinished()
        {
            _quizSession?.FinishCurrentQuestion();
        }

        [Then]
        public void QuizSessionShouldHaveStatusFinished()
        {
            _quizSession?.QuizState.Should().Be(QuizSessionAggregate.State.Finished);
        }
    }
}
