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
	public class UserServices : IUserServices
	{
		private TwitterContext _dbContext;

		public UserServices(IHttpContextAccessor httpAccessor)
		{
			_dbContext = (TwitterContext)httpAccessor.HttpContext.RequestServices.GetService(typeof(TwitterContext));

		}

		public void AddUsers(UserDto userDto)
		{

			_dbContext.Users.Add(new User
			{
				UserName = userDto.UserName,
				Password = userDto.Password,
				Name = userDto.Name,
				LastName = userDto.LastName,
				Email = userDto.Email,
				CreateDate = userDto.CreateDate,
				Photo = userDto.Photo
			});

			_dbContext.SaveChanges();

		}



		public void Delete(UserDto user)
		{
			throw new NotImplementedException();
		}

		public User GetUser(string name)
		{
			var model = _dbContext.Users.Where(x => x.UserName == name).FirstOrDefault();
			return model;


		}

		public UserDto GetByUserName(string userName)
		{
			var user = GetUser(userName);
			return new UserDto
			{
				UserId = user.UserId,
				Name = user.Name,
				LastName = user.LastName,
				Email = user.Email,
				Password = user.Password,
				UserName = user.UserName,
				CreateDate = null,
				Photo = null
			};


		}

		public List<UserDto> GetUsers()
		{

			var model = _dbContext.Users.Select(m => new UserDto
			{

				UserId = m.UserId,
				UserName = m.UserName,
				Name = m.Name,
				LastName = m.LastName,
				CreateDate = m.CreateDate,
				Email = m.Email,
				Password = m.Password,
				Photo = m.Photo


			}).ToList();

			return model;

		}

		public bool LoginControl(string userName, string password)
		{

			var indexUserNamePassword = _dbContext.Users.Any(x => x.UserName == userName && x.Password == password);


			if (indexUserNamePassword)
			{
				return true;
			}

			else
			{
				return false;
			}

		}

		public UserDto GetUserById(int id)
		{
			var model = _dbContext.Users.Where(x => x.UserId == id).Select(u => new UserDto
			{
				UserId = u.UserId,
				Name = u.Name,
				LastName = u.LastName,
				UserName = u.UserName,
				CreateDate = u.CreateDate,
				Email = u.Email,
				Password = u.Password,
				Photo = u.Photo,

			}).FirstOrDefault();


			return model;
		}

		public List<UserDto> GetUsersByUserName(string username)
		{

			var model = _dbContext.Users.Where(x => x.UserName.Contains(username)).Select(m => new UserDto
			{
				UserId=m.UserId,
				UserName=m.UserName,
				Name=m.Name,
				LastName=m.LastName,
				CreateDate=m.CreateDate,
				Email=m.Email,
				Password=m.Password,
				Photo=m.Photo
				
			}).ToList();

			return model;

		}
	}
}
