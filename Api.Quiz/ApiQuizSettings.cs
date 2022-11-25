using BaseImplementationLib.RabbitMq;
using Infrastructure.Quiz.Authentications;
using Infrastructure.Quiz.Databases;

namespace Api.Quiz
{
    public class ApiQuizSettings : IMongoRepositorySettings, IAuthenticationSettings, IMqSettings
    {
        public string MongoConnectionString { get; } = "mongodb://localhost:27017";

        public string MongoDatabase { get; } = "QuizDatabase";

        public string Key { get; } = "SuperSecretQuizKey";

        public int ExpireTimeInSeconds { get; } = 1000;

        public string MqHostName { get; } = "localhost";
    }
}
