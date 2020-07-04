using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterCore.Common.Dtos
{
	public class TweetDto
	{
		public int TweetId { get; set; }

		public int UserId { get; set; }

		public string Name { get; set; }

		public string LastName { get; set; }

		
		public string TweetText { get; set; }

		public int LikeCount { get; set; }

		public int CommentCount { get; set; }

		public int RetweetCount { get; set; }



		public override string ToString()
		{
			return this.TweetText;
		}

	}
}
