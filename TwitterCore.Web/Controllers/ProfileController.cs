using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TwitterCore.Business.Services.Interfaces;
using TwitterCore.Common.Dtos;
using TwitterCore.Domain.Entities;

namespace TwitterCore.Web.Controllers
{
    public class ProfileController : Controller
    {
		private IUserServices _userServices;
		private ITweetServices _tweetServices;
		private IFollowServices _followServices;

		public ProfileController(IUserServices userServices, ITweetServices tweetServices, IFollowServices followServices)
		{
			_userServices = userServices;
			_tweetServices = tweetServices;
			_followServices = followServices;
		}


		public IActionResult Index(int Id)
        {
			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));

			var model = _userServices.GetUserById(Id);

			var model2 = _tweetServices.GetTweetsById(model.UserId);
			

			UserTweetDto userTweetDto = new UserTweetDto();
			
			userTweetDto.userDto = model;
			
			userTweetDto.tweetList = model2;

			userTweetDto.loginUser = usermodel;

		    ViewBag.IsFollow=_followServices.isFollowing(usermodel.UserId, model.UserId);

			ViewBag.TweetCount = _tweetServices.CountTweet(Id);
			ViewBag.Follower=_followServices.CountFollower(Id);
			ViewBag.Following = _followServices.CountFollowing(Id);


			return View(userTweetDto);

			
        }
		[HttpPost]
		public IActionResult PostNewTweetForAjax(TweetDto tweetDto)
		{

			var tweet = new Tweet
			{
				UserId = tweetDto.UserId,
				TweetText = tweetDto.TweetText,
				LikeCount = 0,
				RetweetCount = 0,
				CommentCount = 0

			};

			_tweetServices.AddTweets(tweetDto);

			return Json(ModelState.IsValid);
		}

		[HttpPost]
		public IActionResult PostAddFollowForAjax(FollowDto followDto)
		{
			int userId = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User")).UserId;
			var follow = new FollowDto
			{
				FollowerId = userId,
				FollowingId=followDto.FollowingId

			};


			_followServices.AddFollows(follow);

			return Json("/Profile?Id=" + followDto.FollowingId);
		}

		[HttpPost]
		public IActionResult PostDeleteFollowForAjax(FollowDto followDto)
		{
			int userId = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User")).UserId;
			var follow = new FollowDto
			{
				FollowerId = userId,
				FollowingId = followDto.FollowingId

			};


			_followServices.DeleteFollows(follow);

			return Json("/Profile?Id=" + followDto.FollowingId);
		}


	}
}