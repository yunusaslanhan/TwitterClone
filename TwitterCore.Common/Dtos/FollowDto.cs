using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterCore.Common.Dtos
{
	public class FollowDto
	{
		public int FollowerId { get; set; }
		public int FollowingId { get; set; }


		public string FollowingName { get; set; }

		public string FollowingLastName { get; set; }

	}
}
