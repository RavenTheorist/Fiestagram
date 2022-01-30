using Fiestagram.Core.Selfies.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiestagram.Core.Selfies.Infrastructure.Data.TypeConfigurations
{
	class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
	{
		#region Public methods
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("User");

			builder.HasKey(item => item.Id);
		}
		#endregion//Public methods
	}
}
