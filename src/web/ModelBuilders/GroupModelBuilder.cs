using GroupClue.Data;
using GroupClue.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GroupClue.Web.ModelBuilders
{
    public class GroupModelBuilder : IGroupModelBuilder
    {
        private ApplicationDbContext _context;

        public GroupModelBuilder(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<GroupViewModel> GetGroups()
        {
            var results = new List<GroupViewModel>();
            var groups = _context.Groups.Include(g => g.MainImage).Include(u => u.Creator).OrderByDescending(x => x.CreatedAt);
            
            foreach (var group in groups)
            {
                results.Add(new GroupViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    Href = "/group/" + group.Id,
                    Img = group.MainImage.Url,
                    EventCount = 334,
                    MemberCount = 121,
                    CommentCount = 8,
                    Owner = new UserViewModel
                    {
                        Name = group.Creator.Name,
                        AvatarUrl = "http://demo.nrgthemes.com/projects/nrgnetwork/img/a5.png"
                    }
                });
            }
            return results;
        }
    }
}
