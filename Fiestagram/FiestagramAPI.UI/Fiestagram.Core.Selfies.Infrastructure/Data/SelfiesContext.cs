using Fiestagram.Core.Framework;
using Fiestagram.Core.Selfies.Domain;
using Fiestagram.Core.Selfies.Infrastructure.Data.TypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiestagram.Core.Selfies.Infrastructure.Data
{
	public class SelfiesContext : IdentityDbContext, IUnitOfWork
	{
		#region Constructors
		public SelfiesContext([NotNullAttribute] DbContextOptions options) : base(options) { }
		public SelfiesContext() : base() { }
		#endregion//Constructors
		#region Properties
		public DbSet<Selfie> Selfies { get; set; }
		public DbSet<User> Users { get; set; }

		public DbSet<Picture> Pictures { get; set; }
		#endregion//Properties

		#region Internal methods
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new SelfieEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
		}
		#endregion//Internal methods
	}
}
