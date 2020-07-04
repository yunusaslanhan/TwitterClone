using System;
using System.Collections.Generic;
using System.Text;
using TwitterCore.Common.Dtos;

namespace TwitterCore.Business.Services.Interfaces
{
	public interface IFollowServices
	{
		void AddFollows(FollowDto followDto);
		void DeleteFollows(FollowDto followDto);
		bool isFollowing(int loginId, int userId);
		int CountFollower(int id);
		int CountFollowing(int id);
		List<UserDto> FollowingUsers(int id);

	}
}
