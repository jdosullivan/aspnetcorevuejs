using GroupClue.Web.Models;
using Newtonsoft.Json;
using System;

namespace GroupClue.Web.Models
{
    public class GroupViewModel
    {
        public GroupViewModel() { }

        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }


        [JsonProperty(PropertyName = "href")]
        public string Href { get; set; }

        [JsonProperty(PropertyName = "img")]
        public string Img { get; set; }


        [JsonProperty(PropertyName = "eventCount")]
        public int EventCount { get; set; }


        [JsonProperty(PropertyName = "memberCount")]
        public int MemberCount { get; set; }

        [JsonProperty(PropertyName = "commentCount")]
        public int CommentCount { get; set; }


        [JsonProperty(PropertyName = "owner")]
        public UserViewModel Owner { get; set; }       
    }
}
