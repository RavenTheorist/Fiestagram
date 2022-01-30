using FiestagramAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiestagram.API.UI.Application.Commands
{
	/// <summary>
	/// Command to add one selfie into the database
	/// </summary>
	public class AddSelfieCommand : IRequest<SelfieDTO>
	{
		#region Properties
		public SelfieDTO SelfieDto { get; set; }
		#endregion//Properties
	}
}
