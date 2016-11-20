using GroupClue.Data;
using GroupClue.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data.Models
{
	public enum EventState
	{
		Published,
		Unpublished,
		Deleted
	}

    public class Event : BaseModel
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public long Id { get; set; }

		[MaxLength(128)]
		public string Name { get; set; }

		[MaxLength(Int32.MaxValue)]
		public string Description { get; set; }

		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		[DefaultValue(EventState.Unpublished)]
		[Required]
		public EventState State { get; set; }

		public string Location { get; set; }
		
		public Group Group { get; set; }

		public ICollection<EventImage> EventImages { get; set; }

		public Image MainImage { get; set; }

										   //  rsvps: DataType.VIRTUAL,
	}
}
