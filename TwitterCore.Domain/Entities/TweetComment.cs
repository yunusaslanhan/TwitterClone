using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TwitterCore.Domain.Entities
{
	[Table("TweetComments")]
	public class TweetComment
	{
		[Key]
		public int TweetCommentId { get; set; }

		[Required]
		public int TweetId { get; set; }
		public Tweet tweetId { get; set; }

		[Required]
		public int UserId { get; set; }
		public User userId { get; set; }

		[Required]
		[StringLength(140)]
		public string CommentText { get; set; }



	}
}
