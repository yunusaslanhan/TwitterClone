using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TwitterCore.Domain.Entities
{
	[Table("Messages")]
	public class Message
	{
		[Key]
		public int MessageId { get; set; }
		[ForeignKey("FromUser")]
		public int FromId { get; set; }
		
		public User FromUser { get; set; }

		[ForeignKey("ToUser")]
		public int ToId { get; set; }
	
		public User ToUser { get; set; }

		[Required]
		[StringLength(140)]
		public string MessageText { get; set; }



	}
}
