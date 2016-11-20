using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GroupClue.Models;
using System.ComponentModel;

namespace GroupClue.Data
{    public abstract class BaseModel
	{
		[Required]
		public string CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser Creator { get; set; }

        private DateTime? dateCreated = null;
        public virtual DateTime CreatedAt {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.UtcNow;
            }

            set { dateCreated = value; }
        }

		public string UpdatedBy { get; set; }

		[ForeignKey("UpdatedBy")]
        public virtual ApplicationUser Updater { get; set; }
        
        public virtual DateTime UpdatedAt { get; set; }
        
    }
}