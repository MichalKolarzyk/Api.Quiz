using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz.Databases
{
    public interface IMongoRepositorySettings
    {
        string MongoConnectionString { get; }
        string MongoDatabase { get; }
    }
}
