using data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupClue.Data.Models
{
    public enum GroupState {
        Deleted = -1,
        Enabled = 0, 
        Disabled = 1       
    }

    public class Group : BaseModel
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
        public long Id { get; set; }

        [MaxLength(128), MinLength(3)]
        public string Name { get; set; }

        [MaxLength(Int32.MaxValue)]
        public string Description { get; set; }

        [DefaultValue(GroupState.Enabled)]    
        public GroupState State { get; set; }
        
		public Image MainImage { get; set; }

		public List<Event> Events { get; set; }
	}
}