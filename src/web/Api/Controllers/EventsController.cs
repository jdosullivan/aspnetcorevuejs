using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GroupClue.Data;
using Microsoft.EntityFrameworkCore;
using data.Models;

namespace GroupClue.Api.Controllers
{
	[Route("api/[controller]")]
    public class EventsController : Controller
    {
		private ApplicationDbContext _context;

		public EventsController(ApplicationDbContext context)
		{
			_context = context;
		}
		
		//[Route("api/groups")]
		public IEnumerable<Event> Index()
		{
			return _context.Events.Include(g => g.MainImage);
		}

		[HttpPost]
		//[Route("api/groups")]
		public IActionResult Create([FromBody] Event ev)
		{
			if (ev == null || !ModelState.IsValid)
			{
				return BadRequest(ModelState.Values.SelectMany(m => m.Errors));
			}

			_context.Events.Add(ev);
			_context.SaveChanges();

			return CreatedAtRoute("GetEvent", new { id = ev.Id }, ev);
		}

	}
}
