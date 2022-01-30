using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fiestagram.Core.Selfies.Domain
{
	public class User
	{
		#region Properties
		public int Id { get; set; }

		public List<Selfie> Selfies { get; set; }
		#endregion//Properties
	}
}
