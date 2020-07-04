using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TwitterCore.Domain.Entities
{
	[Table("TweetLikes")]
	public class TweetLike
	{
		[Key]
		public int TweetLikeId { get; set; }

		[Required]
		public int TweetId { get; set; }
		public Tweet tweetId { get; set; }

		[Required]
		public int UserId { get; set; }
		public User userId { get; set; }

	}
}
