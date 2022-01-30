using Fiestagram.API.UI.Application.Commands;
using Fiestagram.Core.Selfies.Domain;
using FiestagramAPI.UI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fiestagram.API.UI.Controllers
{
	public class AddSelfieHandler : IRequestHandler<AddSelfieCommand, SelfieDTO>
	{
		#region Fields
		private readonly ISelfieRepository _repository = null;
		#endregion//Fields

		#region Constructors
		public AddSelfieHandler(ISelfieRepository repository)
		{
			this._repository = repository;
		}
		#endregion//Constructors

		#region Public methods
		public Task<SelfieDTO> Handle(AddSelfieCommand request, CancellationToken cancellationToken)
		{
			SelfieDTO result = null;

			// Don't set the ID, because it increments automatically...
			Selfie addedSelfie = this._repository.AddOne(new Selfie()
			{
				Title = request.SelfieDto.Title,
				ImagePath = request.SelfieDto.ImagePath,
			});

			// Save to database
			_repository.UnitOfWork.SaveChanges();

			if (addedSelfie != null)
			{
				// ...get the auto generated ID
				request.SelfieDto.Id = addedSelfie.Id;
				result = request.SelfieDto;
			}

			return Task.FromResult(result);
		}
		#endregion//Public methods
	}
}
