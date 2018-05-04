using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthServer.Models
{
    public class Resource
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string ResourceID { get; set; }
        public string ResourceName { get; set; }
        public string ResourceCode { get; set; }
    }
}
