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
    public class HomePageController : Controller
    {
		private ITweetServices _tweetServices;
		private IUserServices _userServices;

		public HomePageController(ITweetServices tweetServices, IUserServices userServices)
		{

			_tweetServices = tweetServices;
			_userServices = userServices;
		}


		public IActionResult Index()
        {

			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));

			var tweetListModel=_tweetServices.GetTweetsById(usermodel.UserId);

			var list = _tweetServices.GetFollowingTweetsById(usermodel.UserId);

			tweetListModel.AddRange(list);

      		tweetListModel=tweetListModel.OrderByDescending(x => x.TweetId).ToList();

			var userListModel = _userServices.GetUsers();

			UserTweetDto userTweetDto = new UserTweetDto();

			userTweetDto.userDto = usermodel;
			userTweetDto.tweetList = tweetListModel;



			userTweetDto.UserList = userListModel;

			return View(userTweetDto);
		}

		[HttpGet]
		public IActionResult LoginHomePage() {
			

			UserDto model =JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));
			

			return View(model);
		}

		//[HttpPost]
		//public IActionResult PostNewTweet(TweetDto tweetDto)
		//{
		//	//ViewBag
		//	//ViewData

		//	ViewBag.IsPost = true;

		//	if (ModelState.IsValid)
		//	{
		//		ViewBag.Result = true;
		//	}
		//	else
		//	{
		//		ViewBag.Result = false;
		//	}

		//	//ViewBag.Result = model != null ? true : false;
		//	//ViewData["Result"] = model != null;

		//	return View("Index");
		//}



		[HttpPost]
		public IActionResult PostNewTweetForAjax(TweetDto tweetDto)
		{

			var tweet = new Tweet
			{
				UserId = tweetDto.UserId,
				TweetText = tweetDto.TweetText,
				LikeCount = 0,
				RetweetCount = 0,
				CommentCount=0
				
			};

			_tweetServices.AddTweets(tweetDto);
			
			return Json(ModelState.IsValid);
		}

		[HttpPost]
		public IActionResult Deneme()
		{
			
			return View();

		}


		[HttpPost]
		public IActionResult Search(string UserName)
		{
			var userList = _userServices.GetUsersByUserName(UserName);

			return View(userList);

		}
	}
}