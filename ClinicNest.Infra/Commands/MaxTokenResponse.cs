using Newtonsoft.Json;
using System;

namespace ClinicNest.Infra.ApiClients.Commands
{
    public class MaxTokenResponse
    {
        private readonly DateTime _utcExpirationDate;

        public MaxTokenResponse(int expiresIn, string accessToken)
        {
            ExpiresIn = expiresIn;
            AccessToken = accessToken;

            _utcExpirationDate = DateTime.UtcNow.AddSeconds(ExpiresIn);
        }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; }

        [JsonProperty("access_token")] 
        public string AccessToken { get; }

        public bool IsExpired() => DateTime.UtcNow > _utcExpirationDate;
    }
}