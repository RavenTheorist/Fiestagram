using Fiestagram.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiestagram.Core.Selfies.Domain
{
	/// <summary>
	/// Repository to manage Selfies
	/// </summary>
	public interface ISelfieRepository : IRepository
	{
		/// <summary>
		/// Get all the Selfies
		/// </summary>
		ICollection<Selfie> GetAll(int userId);

		/// <summary>
		/// Add one selfie in the database
		/// </summary>
		/// <param name="selfie">Given Selfie to add</param>
		/// <returns>Added Selfie</returns>
		Selfie AddOne(Selfie selfie);

		/// <summary>
		/// Creates a new picture
		/// </summary>
		/// <param name="url">Picture url</param>
		/// <returns>Created picture</returns>
		Picture AddOnePicture(string url);
		//Picture AddOnePicture(int selfieId, string url);
	}
}
