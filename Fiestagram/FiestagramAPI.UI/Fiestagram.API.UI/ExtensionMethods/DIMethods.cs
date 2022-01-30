using Fiestagram.API.UI;
using Fiestagram.Core.Selfies.Domain;
using Fiestagram.Core.Selfies.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiestagramAPI.UI.ExtensionMethods
{
	public static class DIMethods
	{
		#region Public methods
		/// <summary>
		/// Prepare custom dependency injections
		/// </summary>
		/// <param name="services"></param>
		public static IServiceCollection AddInjections(this IServiceCollection services)
		{
			services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
			services.AddMediatR(typeof(Startup));

			return services;
		}
		#endregion//Public methods
	}
}
