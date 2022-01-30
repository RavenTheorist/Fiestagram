using FiestagramAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiestagram.API.UI.Application.Queries
{
	/// <summary>
	/// Query to select all selfies (through a DTO class)
	/// </summary>
	public class SelectAllSelfiesQuery : IRequest<List<SelfieResumeDTO>>
	{
		#region Properties
		public int UserId { get; set; }
		#endregion
	}
}
