using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterCore.Common.Dtos
{
	public class UserDto
	{
		public int UserId { get; set; }

		public string UserName { get; set; }

		public string Name { get; set; }

		public string LastName { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public string CreateDate { get; set; }

		public string Photo { get; set; }


		
		public override string ToString()
		{
			return this.UserName;
		}
	}
}
