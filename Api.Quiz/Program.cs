using Api.Quiz;
using Application.Quiz;
using Domain.Quiz;
using FluentValidation;
using Infrastructure.Quiz;
using Infrastructure.Quiz.Databases;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(AssemblyApiQuiz.Assembly, AssemblyApplicationQuiz.Assembly, AssemblyDomainQuiz.Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<AssemblyDomainQuiz>();

builder.Services.AddRepositoryFactory("mongodb://localhost:27017", "QuizDatabase");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
