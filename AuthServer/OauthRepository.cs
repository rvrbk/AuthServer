using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AuthServer
{
    public class OauthRepository : IOauthRepository
    {
        private readonly OauthContext _context = null;

        public OauthRepository(IOptions<Settings> settings)
        {
            _context = new OauthContext(settings);
        }

        public Client AddClient(Client client)
        {
            try
            {
                _context.Clients.InsertOne(client);

                return client;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Resource AddResource(Resource resource)
        {
            try
            {
                _context.Resources.InsertOne(resource);

                return resource;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Client GetClient(ObjectId id)
        {
            try
            {
                return _context.Clients.Find(client => client.BsonID == id).FirstOrDefault();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public Resource GetResource(ObjectId id)
        {
            try
            {
                return _context.Resources.Find(resource => resource.BsonID == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Resource> GetResources()
        {
            throw new NotImplementedException();
        }

        public bool RemoveClient(ObjectId id)
        {
            try
            {
                DeleteResult result = _context.Clients.DeleteOne(client => client.BsonID == id);

                return result.IsAcknowledged;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool RemoveResource(ObjectId id)
        {
            try
            {
                DeleteResult result = _context.Resources.DeleteOne(resource => resource.BsonID == id);

                return result.IsAcknowledged;
            }
            catch(Exception e) 
            {
                throw e;
            }
        }

        public bool UpdateClient(ObjectId id, Client client)
        {
            try
            {
                UpdateResult result = _context.Clients.UpdateOne(c => c.BsonID == id, client.ToJson());

                return result.IsAcknowledged;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool UpdateResource(ObjectId id, Resource resource)
        {
            throw new NotImplementedException();
        }
    }
}
