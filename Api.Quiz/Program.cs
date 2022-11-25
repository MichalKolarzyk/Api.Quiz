using Api.Quiz;
using Api.Quiz.Middelwares;
using Api.Quiz.Services;
using Application.Quiz;
using BaseImplementationLib;
using BaseImplementationLib.RabbitMq;
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

builder.Services.ReqisterMessageQueue(settings);
builder.Services.RegisterMqExchange(new MqExchange { Name = "StartQuizExchange"});
builder.Services.RegisterMqQueueBinding(new MqQueueBind { ExchangeName = "StartQuizExchange", QueueName = "Queue" });


var app = builder.Build();

app.UseMq();

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
