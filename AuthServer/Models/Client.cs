using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthServer.Models
{
    public class Client
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string ClientID { get; set; }
        public IEnumerable<string> ClientSecrets { get; set; }
        public string AllowedScopes { get; set; }
    }
}
