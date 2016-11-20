using GroupClue.Data;
using GroupClue.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data.Models
{
	public class Tag : BaseModel
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public long Id { get; set; }

		[MaxLength(64)]
		[Required]
		public string Name { get; set; }

		public string Description { get; set; }
		public ICollection<GroupTag> GroupTags { get; set; }
	}
}
