using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GroupClue.Web.Models
{
    public class ClientState
    {
        public ClientState()
        {
            User = new UserViewModel();
        }

        [JsonProperty(PropertyName = "groups")]
        public IEnumerable<GroupViewModel> Groups { get; set; }

        [JsonProperty(PropertyName = "currentGroup")]
        public GroupViewModel CurrentGroup { get; set; }
        
        [JsonProperty(PropertyName = "showNewGroupModal")]
        public bool ShowNewGroupModal { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string RequestUrl { get; set; }

        [JsonProperty(PropertyName = "api_url")]
        public string APIUrl { get; set; }

        [JsonProperty(PropertyName = "user")]
        public UserViewModel User { get; set; }


        [JsonProperty(PropertyName = "authCookieName")]
        public string AuthCookie { get { return "auth_tokens"; } }
    }
}
