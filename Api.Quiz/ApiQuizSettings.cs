using Application.Quiz.Authentications;
using BaseImplementationLib.RabbitMq;
using Infrastructure.Quiz.Authentications;
using Infrastructure.Quiz.Databases;

namespace Api.Quiz
{
    public class ApiQuizSettings : IMongoRepositorySettings, IAuthenticationSettings, IMqSettings
    {
        public string MongoConnectionString { get; } = Environment.GetEnvironmentVariable("QUIZAPI_MONGODB_CONNECTIONSTRING") ?? "mongodb://localhost:27017";

        public string MongoDatabase { get; } = Environment.GetEnvironmentVariable("QUIZAPI_MONGODB_DATABASE_NAME") ?? "QuizDatabase";

        public string Key { get; } = Environment.GetEnvironmentVariable("QUIZAPI_SECRET_KEY") ?? "SuperSecretQuizKey";

        public int ExpireTimeInSeconds { get; } = int.Parse(Environment.GetEnvironmentVariable("QUIZAPI_AUTH_EXPIRE_TIME") ?? "10000");

        public string MqHostName { get; } = Environment.GetEnvironmentVariable("RABBITMQ_HOST_NAME") ?? "localhost";
    }
}
