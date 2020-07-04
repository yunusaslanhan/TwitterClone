using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterCore.Common.Dtos
{
	public class UserTweetDto
	{
		public UserDto userDto { get; set; }

		public UserDto loginUser { get; set; }

		public TweetDto tweetDto { get; set; }

		public List<TweetDto> tweetList { get; set; }

		public List<UserDto> UserList { get; set; }

	}
}
