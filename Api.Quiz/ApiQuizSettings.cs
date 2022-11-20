using Infrastructure.Quiz.Databases;

namespace Api.Quiz
{
    public class ApiQuizSettings : IMongoRepositorySettings
    {
        public string MongoConnectionString { get; } = "mongodb://localhost:27017";

        public string MongoDatabase { get; } = "QuizDatabase";

    }
}
