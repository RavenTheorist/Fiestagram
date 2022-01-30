using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiestagramAPI.UI.Application.DTOs
{
	public class SelfieResumeDTO
	{
		#region Properties
		public int NbSelfiesFromThisUser { get; set; }
		public string Title { get; set; }
		public int UserId { get; set; }
		#endregion//Properties
	}
}
