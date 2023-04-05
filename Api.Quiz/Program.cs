using Api.Quiz;
using Api.Quiz.Middelwares;
using Api.Quiz.Services;
using Application.Quiz;
using Application.Quiz.QuizSession.ExtenrnalEvents;
using Application.Quiz.Services;
using BaseImplementationLib;
using BaseImplementationLib.RabbitMq;
using Domain.Quiz;
using FluentValidation;
using Infrastructure.Quiz;
using Infrastructure.Quiz.Databases;
using Infrastructure.Quiz.Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;

var settings = new Settings();

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

builder.Services.AddScoped<ICurrentIdentity, HttpContextService>();
builder.Services.AddScoped<CurrentAccount>();
builder.Services.AddScoped<ExceptionMiddleware>();

//builder.Services.ReqisterMessageQueue(settings);
//builder.Services.RegisterMqQueue(new MqQueue { Name = "AppEventListener" });
//builder.Services.RegisterMqExchange(new MqExchange { Name = "StartQuizExchange" });
//builder.Services.RegisterMqQueueBinding(new MqQueueBind { ExchangeName = "StartQuizExchange", QueueName = "AppEventListener" });

//builder.Services.AddScoped<ISessionComunicator, ServiceSessionHubInternal>();
//builder.Services.AddSignalR();

//builder.Services.AddExternalEvents();


var app = builder.Build();
app.UseMq();
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .WithMethods("GET", "POST", "PUT", "DELETE")
    .AllowCredentials();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.MapHub<ServiceSessionHub>(typeof(ServiceSessionHub).Name);

app.UseMiddleware<ExceptionMiddleware>();


app.Run();
