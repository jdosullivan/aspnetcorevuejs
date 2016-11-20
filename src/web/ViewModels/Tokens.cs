using GroupClue.Data;
using GroupClue.Web.Models;
using System;

namespace GroupClue.Web.ViewModels
{
    public class Tokens
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
        public double expires { get; set; }
    }    
}
