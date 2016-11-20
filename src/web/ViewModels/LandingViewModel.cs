using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupClue.ViewModels
{
    public class LandingViewModel
    {
		public string WebsiteName { get; set; }
		public string TagLine { get; set; }

		public IList<ServiceViewModel> Services { get; set; }
	}

	public class ServiceViewModel
	{
		public string Icon { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }
	}
}
