using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
	public class FollowServices:IFollowServices
	{
		private TwitterContext _dbContext;

		public FollowServices(IHttpContextAccessor httpAccessor)
		{
			_dbContext = (TwitterContext)httpAccessor.HttpContext.RequestServices.GetService(typeof(TwitterContext));
			
		}

		public void AddFollows(FollowDto followDto)
		{

			_dbContext.Follows.Add(new Follow
			{
				FollowerId=followDto.FollowerId,
				FollowingId=followDto.FollowingId

			});

			_dbContext.SaveChanges();


		}

		public void DeleteFollows(FollowDto followDto)
		{

			_dbContext.Follows.Remove(new Follow
			{
				FollowerId = followDto.FollowerId,
				FollowingId = followDto.FollowingId

			});

			_dbContext.SaveChanges();


		}


		public bool isFollowing(int loginId,int userId)
		{

			return _dbContext.Follows.Any(f => (f.FollowerId==loginId) && (f.FollowingId == userId));


		}

		public int CountFollower(int id)
		{
			return _dbContext.Follows.Count(f => f.FollowerId == id);

		}

		public int CountFollowing(int id)
		{
			return _dbContext.Follows.Count(f => f.FollowingId == id);

		}


		public List<UserDto> FollowingUsers(int id)
		{
			List<UserDto> dto = _dbContext.Follows
				.Where(f => f.FollowerId == id)
				.Include(u => u.followerUser)
				.Select(f => f.followingUser)
				.Select(user => new UserDto
				{

					UserName=user.UserName,
					UserId=user.UserId,
					Name=user.Name,
					LastName=user.LastName,
					Email=user.Email,
					Password=user.Password,
					CreateDate=user.CreateDate,
					Photo=user.Photo
					
				}).ToList();
			return dto;
		}

	}
}
