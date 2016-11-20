using Microsoft.AspNetCore.Mvc;
using GroupClue.Web.Models;
using GroupClue.Web.ModelBuilders;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace GroupClue.Controllers
{
    public class HomeController : Controller
    {
        private IGroupModelBuilder _groupModelBuilder;
        private readonly IConfiguration _configuration;

        public HomeController(IGroupModelBuilder groupModelBuilder, IConfiguration configuration)
		{
            _groupModelBuilder = groupModelBuilder;
            _configuration = configuration;
		}

        // GET: /<controller>/
        public IActionResult Index()
        {
            var initialValues = new ClientState {
                ShowNewGroupModal = false,
                APIUrl = _configuration["API_URL"],
                RequestUrl = this.HttpContext.Request.Path             
            };
            
            var tokenString = Request.Cookies[initialValues.AuthCookie];
            if (!string.IsNullOrEmpty(tokenString)) {
                var tokens = JObject.Parse(tokenString);
                if (tokens.HasValues) {
                    initialValues.User.AccessToken = tokens.Value<string>("access_token");
                    initialValues.User.RefreshToken = tokens.Value<string>("refresh_token");
                    initialValues.User.Expires = tokens.Value<double>("expires");
                    initialValues.User.ExpiresIn = tokens.Value<int>("expires_in");
                }
            }

            return View(initialValues);
        }
        
        
    }

}
