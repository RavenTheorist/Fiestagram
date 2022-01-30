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
	class SelfieEntityTypeConfiguration : IEntityTypeConfiguration<Selfie>
	{
		#region Public methods
		public void Configure(EntityTypeBuilder<Selfie> builder)
		{
			builder.ToTable("Selfie");

			builder.HasKey(item => item.Id);
			builder.HasOne(item => item.User).WithMany(item => item.Selfies);
		}
		#endregion//Public methods
	}
}
