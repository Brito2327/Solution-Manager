using System.Collections.Generic;

namespace ClinicNest.Infra.ApiClients.Commands
{
    public class MaxTokenRequest
    {
        public MaxTokenRequest(string grantType, string resource, string clientId,
            string userName, string passWord)
        {
            Credentials = new Dictionary<string, string>
            {
                {"grant_type", grantType},
                {"resource", resource},
                {"client_id", clientId},
                {"username", userName},
                {"password", passWord}
            };
        }
        
        public Dictionary<string, string> Credentials { get; }
    }
}