using GroupClue.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupClue.Web.ModelBuilders
{
    public interface IGroupModelBuilder
    {
        List<GroupViewModel> GetGroups();
    }
}
