using System;
using System.Collections.Generic;
using System.Text;
using TwitterCore.Common.Dtos;
using TwitterCore.Domain.Entities;

namespace TwitterCore.Business.Services.Interfaces
{
	public interface IUserServices
	{
		
		void AddUsers(UserDto userDto);
		List<UserDto> GetUsers();
		User GetUser(string name);
		UserDto GetUserById(int id);
		void Delete(UserDto user);
	    bool LoginControl(string userName,string password);
		UserDto GetByUserName(string userName);
		List<UserDto> GetUsersByUserName(string username);


	}
}
