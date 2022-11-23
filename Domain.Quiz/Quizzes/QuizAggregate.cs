using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Quizzes
{
    public class QuizAggregate : AggregateRoot
    {
        public QuizAggregate(Guid themeId, Guid workspaceId)
        {
            Id = Guid.NewGuid();
            ThemeId = themeId;
            WorkspaceId = workspaceId;
        }

        public List<Guid> QuestionIds { get; set; } = new();

        public Guid ThemeId { get; set; }

        public Guid WorkspaceId { get; set; }

        public void UpdateQuestions(List<Guid> questionIds)
        {
            QuestionIds = questionIds;
        }
    }
}
