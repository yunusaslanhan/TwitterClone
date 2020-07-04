using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TwitterCore.Domain.Entities
{
	[Table("Users")]
	public class User
	{
		[Key]
		public int UserId { get; set; }

		[Required]
		[StringLength(50)]
		public string UserName { get; set; }

		[Required]
		[StringLength(50)]
		public string Password { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		public string Email { get; set; }

		[Required]
		[StringLength(50)]
		public string LastName { get; set; }

		
		[StringLength(50)]
		public string CreateDate { get; set; }

		
		[StringLength(100)]
		public string Photo { get; set; }




		public virtual ICollection<Tweet> Tweets { get; set; }

		[InverseProperty("FromUser")]
		public virtual ICollection<Message> FromMessage { get; set; }

		[InverseProperty("ToUser")]
		public virtual ICollection<Message> ToMessage { get; set; }

		[InverseProperty("followerUser")]
		public virtual ICollection<Follow> Follower { get; set; }

		[InverseProperty("followingUser")]
		public virtual ICollection<Follow> Following { get; set; }

		public virtual ICollection<TweetLike> TweetLike { get; set; }
		public virtual ICollection<TweetComment> TweetComment { get; set; }
		public virtual ICollection<Retweet> Retweet { get; set; }



	}
}
