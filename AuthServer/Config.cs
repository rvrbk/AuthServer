using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources
        {
            get
            {
                return new List<ApiResource>
                {
                    new ApiResource("api")
                };
            }
            set
            {
                ApiResources = value;
            }
        }

        public static IEnumerable<Client> ApiClients
        {
            get
            {
                return new List<Client>
                {
                    new Client
                    {
                        ClientId = "1",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = { "api" }
                    }
                };
            }
            set
            {
                ApiClients = value;
            }
        }
    }
}
