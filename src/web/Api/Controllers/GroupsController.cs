using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GroupClue.Data;
using GroupClue.Data.Models;
using Microsoft.EntityFrameworkCore;
using GroupClue.Web.Models;
using Microsoft.AspNetCore.Authorization;
using AspNet.Security.OAuth.Validation;

namespace GroupClue.Api.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : Controller
    {
		private ApplicationDbContext _context;

		public GroupsController(ApplicationDbContext context)
		{
			_context = context;
		}
        
        [HttpGet]
        public IEnumerable<GroupViewModel> Get()
        {
            var groups = _context.Groups.Include(g => g.MainImage).Include(u => u.Creator).OrderByDescending(g => g.CreatedAt);

            var groupModels = new List<GroupViewModel>();

            foreach(var g in groups)
            {
                groupModels.Add(Convert(g));
            }

            return groupModels;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetGroup")]
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        public GroupViewModel Get(long id)
        {
            var group = _context.Groups.Include(g => g.MainImage).Include(u => u.Creator).FirstOrDefault(x => x.Id == id);

            if (group == null)
                return null;

            return new GroupViewModel
            {
                Id = group.Id,
                Description = group.Description,
                Img = group.MainImage.Url,
                Name = group.Name,
                CommentCount = 1,
                EventCount = 2,
                MemberCount = 3,
                Owner = new UserViewModel
                {
                    Name = group.Creator.Name,
                    AvatarUrl = "http://demo.nrgthemes.com/projects/nrgnetwork/img/a5.png"
                },
                Href = "/" + group.Name
            };
        }
        
		[HttpPost]
		// [Route("api/groups")]
		public ActionResult Create([FromBody] Group group)
		{
            if (group == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors));
            }

            _context.Groups.Add(group);
			_context.SaveChanges();            

            var model = Convert(group);
            
            return CreatedAtRoute("GetGroup", new { id= group.Id }, model);
		}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var group = _context.Groups.FirstOrDefault(x => x.Id == id);
            if (group == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(group);
            _context.SaveChanges();
            return new NoContentResult();
        }

        private static GroupViewModel Convert(Group group)
        {
            return new GroupViewModel
            {
                Id = group.Id,
                Description = group.Description,
                Img = group.MainImage.Url,
                Name = group.Name,
                CommentCount = 1,
                EventCount = 2,
                MemberCount = 3,
                Owner = new UserViewModel
                {
                    Name = "David Graham",
                    AvatarUrl = "http://demo.nrgthemes.com/projects/nrgnetwork/img/a5.png"
                },
                Href = "/" + group.Name
            };
        }
    }
}
