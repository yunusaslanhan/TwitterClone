using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterCore.Business.Context;
using TwitterCore.Business.Services.Interfaces;
using TwitterCore.Common.Dtos;
using TwitterCore.Domain.Entities;

namespace TwitterCore.Business.Services
{
	public class TweetServices : ITweetServices
	{
		private TwitterContext _dbContext;

		public TweetServices(IHttpContextAccessor httpAccessor)
		{
			_dbContext = (TwitterContext)httpAccessor.HttpContext.RequestServices.GetService(typeof(TwitterContext));

		}

		public void AddTweets(TweetDto tweetDto)
		{
			_dbContext.Tweets.Add(new Tweet
			{
				UserId = tweetDto.UserId,
				TweetText = tweetDto.TweetText,
				LikeCount = tweetDto.LikeCount,
				CommentCount=tweetDto.CommentCount,
				RetweetCount=tweetDto.RetweetCount
				
			});

			_dbContext.SaveChanges();



		}


		public List<TweetDto> GetTweetsById(int id)
		{
			
			var model = _dbContext.Tweets.OrderByDescending(m=>m.TweetId).Where(x=>x.UserId==id).Select(m => new TweetDto
			{

				TweetId = m.TweetId,
				UserId =id,
				TweetText=m.TweetText,
				CommentCount=m.CommentCount,
				LikeCount=m.LikeCount,
				RetweetCount=m.RetweetCount,
				Name=_dbContext.Users.Where(a=>a.UserId==id).Select(a=>a.Name).SingleOrDefault(),
				LastName=_dbContext.Users.Where(a=>a.UserId==id).Select(a=>a.LastName).SingleOrDefault(),
				
				

			}).ToList();

			return model;


		}
		public List<TweetDto> GetFollowingTweetsById(int id)
		{
			List<TweetDto> list = new List<TweetDto>();
			var model = _dbContext.Follows.Where(x => x.FollowerId == id).Select(x=>x.FollowingId).ToList();

			foreach (var item in model)
			{
				list.AddRange(GetTweetsById(item));

			}
			
			return list;

		}

		public int CountTweet(int id)
		{
			return _dbContext.Tweets.Count(t => t.UserId == id);

		}



	}
}
