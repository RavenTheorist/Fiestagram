using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiestagram.Core.Selfies.Domain
{
	/// <summary>
	/// User selfie
	/// </summary>
	public class Selfie
	{
		#region Properties
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }

		public int PictureId { get; set; }
		public Picture Picture { get; set; }
		#endregion//Properties
	}
}
