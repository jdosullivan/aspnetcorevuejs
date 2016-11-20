using Newtonsoft.Json;
using System;

namespace GroupClue.Web.Models
{
    public class UserViewModel
    {     
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "avatarUrl")]
        public string AvatarUrl { get; set; }

        [JsonProperty(PropertyName = "authenticated")]
        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); }}

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
        
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }


        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "expires")]
        public double Expires { get; set; }
    }
}
