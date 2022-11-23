using Api.Quiz;
using Api.Quiz.Middelwares;
using Api.Quiz.Services;
using Application.Quiz;
using Domain.Quiz;
using FluentValidation;
using Infrastructure.Quiz;
using Infrastructure.Quiz.Databases;
using MediatR;

var settings = new ApiQuizSettings();

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(AssemblyApiQuiz.Assembly, AssemblyApplicationQuiz.Assembly, AssemblyDomainQuiz.Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<AssemblyApplicationQuiz>();

builder.Services.AddMongoRepository(settings);
builder.Services.AddJwtTokenAuthentication(settings);
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<HttpContextService>();
builder.Services.AddScoped<ExceptionMiddleware>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
