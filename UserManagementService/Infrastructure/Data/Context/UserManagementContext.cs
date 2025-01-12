using MongoDB.Driver;
using Microsoft.Extensions.Options;
using SocialPolitics.UserManagementService.Infrastructure.Data.Models;

namespace SocialPolitics.UserManagementService.Infrastructure.Data.Context;

public class UserManagementContext
{
    private readonly IMongoDatabase _database;

    public UserManagementContext(IOptions<ServiceSettings> options)
    {
        var serviceSettings = options.Value;

        // Create the MongoDB client and connect to the specified database
        var client = new MongoClient(serviceSettings.ConnectionString);
        _database = client.GetDatabase(serviceSettings.DatabaseName);
    }

    // Expose a collection for the "Users" entity
    public IMongoCollection<User> Users => _database.GetCollection<User>("UserDetails");
}
