using GroupClue.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace data.Models
{
    public class Image : BaseModel
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public long Id { get; set; }

		public string Url { get; set; }

		public string Caption { get; set; }

	}
}
