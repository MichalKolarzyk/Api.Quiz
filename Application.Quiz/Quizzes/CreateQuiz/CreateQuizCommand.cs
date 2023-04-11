﻿using Domain.Quiz.Quizzes;
using FluentValidation;
using MediatR;

namespace Application.Quiz.Quizzes.CreateQuiz
{
    public class CreateQuizCommand : IRequest<QuizAggregate>
    {
        public string Name { get; set; } = string.Empty;
    }
}