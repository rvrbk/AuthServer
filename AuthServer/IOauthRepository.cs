using AuthServer.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer
{
    public interface IOauthRepository
    {
        IEnumerable<Resource> GetResources();
        Resource GetResource(ObjectId id);
        IEnumerable<Client> GetClients();
        Client GetClient(ObjectId id);
        Resource AddResource(Resource resource);
        Client AddClient(Client client);
        bool RemoveResource(ObjectId id);
        bool RemoveClient(ObjectId id);
        bool UpdateResource(ObjectId id, Resource resource);
        bool UpdateClient(ObjectId id, Client client);
    }
}
