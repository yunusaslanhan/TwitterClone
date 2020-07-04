using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TwitterCore.Business.Services.Interfaces;
using TwitterCore.Common.Dtos;

namespace TwitterCore.Web.Controllers
{
    public class MessageController : Controller
    {
		private IFollowServices _followServices;
		private IMessageServices _messageServices;

		public MessageController(IFollowServices followServices,IMessageServices messageServices)
		{
			_followServices = followServices;
			_messageServices = messageServices;
		}

		public IActionResult Index()
        {
			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));

			ViewBag.senderMessageId = usermodel.UserId;
			ViewBag.senderMessageName = usermodel.Name;
			ViewBag.senderMessageLastName = usermodel.LastName;



		    var model=_followServices.FollowingUsers(usermodel.UserId);

			return View(model);
        }

		[HttpPost]
		public IActionResult PostNewMessageForAjax(MessageDto messageDto)
		{


			_messageServices.AddMessages(messageDto);

			return Json(ModelState.IsValid);
		}

		[HttpPost]
		public IActionResult PostMessageListForAjax(int ToId)
		{
			int senderId = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User")).UserId;


			List<MessageDto> messages=_messageServices.getMessages(senderId,ToId);
			

			return Json(ModelState.IsValid);
		}
	}
}