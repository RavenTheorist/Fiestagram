﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiestagram.Core.Selfies.Infrastructure.Data
{
	public class SelfiesContextFactory : IDesignTimeDbContextFactory<SelfiesContext>
	{
		#region Public methods
		public SelfiesContext CreateDbContext(string[] args)
		{
			// Build a configuration to be able to access our appSettings.json
			ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

			// Set our custom json file path
			configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings", "appSettings.json"));

			// Build the JSon file into a dictionary to be able to access its data more easily using a IConfigurationRoot
			IConfigurationRoot configurationRoot = configurationBuilder.Build();
			
			// Create a DbContextOptions, to be able to pass some options to our context
			DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

			// Set the DB provider
			builder.UseSqlServer(configurationRoot.GetConnectionString("SelfiesDatabase"), b => b.MigrationsAssembly("Fiestagram.Core.Selfies.Data.Migrations"));

			SelfiesContext context = new SelfiesContext(builder.Options);

			return context;
		}
		#endregion//Public methods
	}
}
