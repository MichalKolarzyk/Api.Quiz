using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Questions
{
    public class QuestionAggregate : AggregateRoot
    {
        public Guid WorkspaceId { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<string> Answers { get; set; } = new();

        public int CorrectAnswerIndex { get; set; }

        public QuestionAggregate(Guid workspaceId, string description, List<string> answers, int correctAnswerIndex)
        {
            WorkspaceId = workspaceId;
            Description = description;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
        }
    }
}
