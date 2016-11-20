using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GroupClue.Models;
using GroupClue.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using data.Models;
using OpenIddict;

namespace GroupClue.Data
{
    public class ApplicationDbContext : OpenIddictDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			builder.Entity<GroupTag>().HasKey(x => new { x.TagId, x.GroupId });
			builder.Entity<EventImage>().HasKey(x => new { x.EventId, x.ImageId });
		}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
			if (!options.IsConfigured) // Running from command line
			{

				var webDir = $"{Directory.GetCurrentDirectory()}\\..\\web";
				var builder = new ConfigurationBuilder()
					.AddJsonFile($"{webDir}\\appsettings.json", optional: false)
					.AddJsonFile($"{webDir}\\appsettings.Development.json", optional: true)
					.AddEnvironmentVariables();

				IConfigurationRoot config = builder.Build();

				options.UseSqlServer(config["Database:ConnectionString"]);
			}
        }

        public DbSet<Group> Groups { get; set; }

		public DbSet<Tag> Tags { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Image> Images { get; set; }
	}

}
