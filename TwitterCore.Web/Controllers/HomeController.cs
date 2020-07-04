using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TwitterCore.Business.Services.Interfaces;
using TwitterCore.Common.Dtos;
using TwitterCore.Domain.Entities;
using TwitterCore.Web.Models;

namespace TwitterCore.Web.Controllers
{
	public class HomeController : Controller
	{
		private IUserServices _userServices;

		public HomeController(IUserServices userServices)
		{

			_userServices = userServices;

		}


		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult PostNewEmployee(UserDto userDto)
		{
			//ViewBag
			//ViewData

			ViewBag.IsPost = true;

			if (ModelState.IsValid)
			{
				ViewBag.Result = true;
			}
			else
			{
				ViewBag.Result = false;
			}

			//ViewBag.Result = model != null ? true : false;
			//ViewData["Result"] = model != null;

			return View("Index");
		}

		[HttpPost]
		public IActionResult PostNewEmployeeForAjax(UserDto userDto)
		{

			
				var user = new User
				{
					Name = userDto.Name,
					LastName = userDto.LastName,
					UserName = userDto.UserName,
					Password = userDto.Password,
					Email = userDto.Email,
					CreateDate = null,
					Photo=null
					
				};
				_userServices.AddUsers(userDto);
				
			

			return Json(ModelState.IsValid);
		}


		public IActionResult PostLoginUserForAjax(UserDto userDto) {

			ViewBag.IsPost = true;

			var model = _userServices.LoginControl(userDto.UserName, userDto.Password);

			if (model)
			{

				var loginUser = JsonConvert.SerializeObject(_userServices.GetByUserName(userDto.UserName));
				HttpContext.Session.SetString("User", loginUser);
				ViewBag.Result = true;

			}
			else
			{
				ViewBag.Result = false;


			}

			return Json(model);
		}





		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
