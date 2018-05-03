using AuthServer.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer
{
    public class OauthContext
    {
        private readonly IMongoDatabase _database;

        public IMongoCollection<Client> Clients
        {
            get
            {
                return _database.GetCollection<Client>("client");
            }
        }

        public IMongoCollection<Resource> Resources
        {
            get
            {
                return _database.GetCollection<Resource>("resource");
            }
        }

        public OauthContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            if(client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }
    }
}
