using Fiestagram.Core.Framework;
using Fiestagram.Core.Selfies.Domain;
using Fiestagram.Core.Selfies.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiestagram.Core.Selfies.Infrastructure.Repositories
{
	public class DefaultSelfieRepository : ISelfieRepository
	{
		#region Fields
		private readonly SelfiesContext _context = null;
		#endregion//Fields
		#region Constructors
		public DefaultSelfieRepository(SelfiesContext context)
		{
			this._context = context;
		}
		#endregion//Constructors

		#region Public methods
		public ICollection<Selfie> GetAll(int userId)
		{
			var query = this._context.Selfies.Include(item => item.User).AsQueryable();

			if (userId > 0)
			{
				query = query.Where(item => item.UserId == userId);
			}

			return query.ToList();
		}

		public Selfie AddOne(Selfie selfie)
		{
			return this._context.Selfies.Add(selfie).Entity;
		}

		public Picture AddOnePicture(string url)
		{
			return this._context.Pictures.Add(new Picture()
			{
				Url = url
			}).Entity;
		}
		#endregion//Public methods

		#region Properties
		public IUnitOfWork UnitOfWork => this._context;
		#endregion//Properties
	}
}
