using System;
using System.Collections.Generic;
using System.Text;
using TwitterCore.Common.Dtos;

namespace TwitterCore.Business.Services.Interfaces
{
	public interface ITweetServices
	{

		void AddTweets(TweetDto tweetDto);
		List<TweetDto> GetTweetsById(int id);
		List<TweetDto> GetFollowingTweetsById(int id);
		int CountTweet(int id);
	}
}
