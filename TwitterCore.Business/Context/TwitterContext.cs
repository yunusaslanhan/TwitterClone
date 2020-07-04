using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterCore.Domain.Entities;

namespace TwitterCore.Business.Context
{
	public class TwitterContext:DbContext
	{
		public TwitterContext(DbContextOptions<TwitterContext> options=null):base (options)
		{
				



		}


		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Tweet> Tweets { get; set; }
		public virtual DbSet<Message> Messages { get; set; }
		public virtual DbSet<Follow> Follows { get; set; }
		public virtual DbSet<TweetLike> TweetLikes { get; set; }
		public virtual DbSet<TweetComment> TweetComments { get; set; }
		public virtual DbSet<Retweet> Retweets { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder) {

			modelBuilder.Entity<Follow>().HasKey(f => new { f.FollowerId, f.FollowingId });
			modelBuilder.Entity<TweetLike>().HasKey(f => new { f.TweetId, f.UserId });
			modelBuilder.Entity<Retweet>().HasKey(f => new { f.UserId, f.TweetId });
			modelBuilder.Entity<TweetComment>().HasKey(f => new { f.UserId, f.TweetId });


			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

		}





	}
}
