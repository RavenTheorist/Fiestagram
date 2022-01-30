using Fiestagram.Core.Selfies.Domain;
using FiestagramAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fiestagram.API.UI.Application.Queries
{
	public class SelectAllSelfiesHandler : IRequestHandler<SelectAllSelfiesQuery, List<SelfieResumeDTO>>
	{
		#region Fields
		private readonly ISelfieRepository _repository = null;
		#endregion//Fields

		#region Constructors
		public SelectAllSelfiesHandler(ISelfieRepository repository)
		{
			this._repository = repository;
		}
		#endregion//Constructors

		#region Public methods
		public Task<List<SelfieResumeDTO>> Handle(SelectAllSelfiesQuery request, CancellationToken cancellationToken)
		{
			var selfiesList = this._repository.GetAll(request.UserId);
			var result = selfiesList.Select(item => new SelfieResumeDTO() { Title = item.Title, UserId = item.User.Id, NbSelfiesFromThisUser = (item.User?.Selfies?.Count).GetValueOrDefault(0) }).ToList();

			return Task.FromResult(result);

		}
		#endregion//Public methods
	}
}
