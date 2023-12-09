using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using OnlineStore.Domain.Entity;
using OnlineStore.Domain.Enum;
using OnlineStore.Domain.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
		{
			Database.EnsureCreated();
		}

		public DbSet<Product> product { get; set; }

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(bulder =>
			{
				bulder.HasData(new User
				{
					Id = 1,
					Name = "Test",
					Password = HashPasswordUsers.HashPassowrd("123"),
					Role = Role.Admin,
					Email = "huntandfishdylo@gmail.com"
                });

				bulder.ToTable("Users").HasKey(x => x.Id);

				bulder.Property(x => x.Id).ValueGeneratedOnAdd();

				bulder.Property(x => x.Name).HasMaxLength(100).IsRequired();

				bulder.Property(x => x.Password).IsRequired();

				bulder.Property(x => x.Email).IsRequired();
			});
		}
	}
}
