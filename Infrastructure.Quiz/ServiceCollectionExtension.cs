using Application.Quiz.Authentications;
using Application.Quiz.Database;
using Infrastructure.Quiz.Authentications;
using Infrastructure.Quiz.Databases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System.Text;

namespace Infrastructure.Quiz
{
    public static class ServiceCollectionExtension
    {
        public static void AddMongoRepository(this IServiceCollection serviceCollection, IMongoRepositorySettings mongoRepositorySettings)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

            serviceCollection.AddScoped<MongoClient>(provider => new MongoClient(mongoRepositorySettings.MongoConnectionString));
            serviceCollection.AddSingleton<IMongoRepositorySettings>(mongoRepositorySettings);
            serviceCollection.AddTransient<IDomainEventDispacher, DomainEventDispacher>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(RepositoryMongoDB<>));
        }

        public static void AddJwtTokenAuthentication(this IServiceCollection serviceCollection, IAuthenticationSettings authenticationSettings)
        {
            serviceCollection.AddSingleton<IAuthenticationSettings>(authenticationSettings);
            serviceCollection.AddScoped<IAuthenticationTokenService, JwtTokenService>();
            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
                options.DefaultScheme = "Bearer";
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.Key)),
                };
            });
        }
    }
}
