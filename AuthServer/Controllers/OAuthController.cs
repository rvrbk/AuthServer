using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AuthServer.Controllers
{
    [Route("")]
    public class OAuthController : Controller
    {
        private readonly IOauthRepository _oauthRepository;

        public OAuthController(IOauthRepository oauthRepository)
        {
            _oauthRepository = oauthRepository;
        }

        [Route("client")]
        [HttpPost]
        public IActionResult AddClient([FromBody]Client client)
        {
            try
            {
                _oauthRepository.AddClient(client);

                return Json(client);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("resource")]
        [HttpPost]
        public IActionResult AddResource([FromBody] Resource resource)
        {
            try
            {
                _oauthRepository.AddResource(resource);

                return Json(resource);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("client/{id}")]
        [HttpGet]
        public IActionResult GetClient(string id)
        {
            try
            {
                Client client = _oauthRepository.GetClient(new ObjectId(id));

                return Json(client);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("resource/{id}")]
        [HttpGet]
        public IActionResult GetResource(string id)
        {            
            try
            {
                Resource resource = _oauthRepository.GetResource(new ObjectId(id));

                return Json(resource);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("client/{id}")]
        [HttpDelete]
        public IActionResult DeleteClient(string id)
        {
            try
            {
                ObjectId objectid = new ObjectId(id);

                Client client = _oauthRepository.GetClient(objectid);

                if(client != null)
                {
                    _oauthRepository.RemoveClient(objectid);

                    return Json(objectid);
                }
                
                return Json(false);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [Route("resource/{id}")]
        [HttpDelete]
        public IActionResult DeleteResource(string id)
        {
            try
            {
                ObjectId objectid = new ObjectId(id);

                Resource resource = _oauthRepository.GetResource(objectid);

                if (resource != null)
                {
                    _oauthRepository.RemoveResource(objectid);

                    return Json(objectid);
                }

                return Json(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Route("client")]
        [HttpPut]
        public IActionResult UpdateClient([FromBody]Client client)
        {
            try
            {
                _oauthRepository.AddClient(client);

                return Json(client);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        /*[Route("client/{id}")]
        [HttpPut]
        public IActionResult UpdateClient([FromBody] Client update)
        {
            try
            {
                //ObjectId objectid = new ObjectId(id);

                //Client client = _oauthRepository.GetClient(objectid);

                //if(client != null)
                //{
                    //_oauthRepository.UpdateClient(objectid, update);

                    //return Json(objectid);
                //}

                return Json(false);
            }
            catch(Exception e)
            {
                throw e;
            }
        }*/
    }
}