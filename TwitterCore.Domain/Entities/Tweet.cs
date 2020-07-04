using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TwitterCore.Domain.Entities
{

	[Table("Tweets")]
	public class Tweet
	{
		[Key]
		public int TweetId { get; set; }

		[Required]
		public int UserId { get; set; }
		public User user { get; set; }


		[Required]
		[StringLength(140)]
		public string TweetText { get; set; }

		[Required]
		public int LikeCount { get; set; }

		[Required]
		public int CommentCount { get; set; }

		[Required]
		public int RetweetCount { get; set; }


		public virtual ICollection<TweetLike> TweetLike { get; set; }
		public virtual ICollection<TweetComment> TweetComment { get; set; }
		public virtual ICollection<Retweet> Retweet { get; set; }
	}
}
