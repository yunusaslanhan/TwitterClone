using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TwitterCore.Domain.Entities
{
	[Table("Follows")]
	public class Follow
	{
		[Key, Column(Order = 0)]
		public int FollowId { get; set; }

		[Key, Column(Order = 1)]
		[ForeignKey("followerUser")]
		public int FollowerId { get; set; }
		public User followerUser { get; set; }


		[Key, Column(Order = 2)]
		[ForeignKey("followingUser")]
		public int FollowingId { get; set; }
		public User followingUser { get; set; }


	}
}
