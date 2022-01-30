using Fiestagram.API.UI.ExtensionMethods;
using Fiestagram.Core.Selfies.Domain;
using Fiestagram.Core.Selfies.Infrastructure.Data;
using FiestagramAPI.UI.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Fiestagram.API.UI.Application.Queries;
using Fiestagram.API.UI.Application.Commands;

namespace Fiestagram.API.UI.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[EnableCors(SecurityMethods.DEFAULT_POLICY)]
	public class SelfiesController : ControllerBase
	{
		#region Fields
		private readonly IMediator _mediator = null;
		private readonly ISelfieRepository _repository = null;
		private readonly IWebHostEnvironment _webHostEnvironement = null;
		#endregion//Fields

		#region Constructors
		public SelfiesController(IMediator mediator, ISelfieRepository repository, IWebHostEnvironment webHostEnvironement)
		{
			this._mediator = mediator;
			this._repository = repository;
			this._webHostEnvironement = webHostEnvironement;
		}
		#endregion//Constructors

		[HttpGet]
		[Route("trucs/{id:int}")]
		public async Task<IActionResult> GetOrderTEST(int id)
		{
			return Ok();
		}

		#region Public methods
		[HttpGet]
		//[EnableCors(SecurityMethods.DEFAULT_POLICY_3)]
		//[DisableCors]
		public IActionResult GetAll([FromQuery]int userId = 0)
		{
			//var model = Enumerable.Range(1, 10).Select(index => new Selfie() { Id = index });
			//return this.StatusCode(StatusCodes.Status204NoContent);

			//var model = this._selfiesContext.Selfies.ToList();
			//var query = from selfie in this._selfiesContext.Selfies
			//			join user in this._selfiesContext.Users on selfie.User.Id equals user.Id
			//			select selfie;

			var param = this.Request.Query["userId"];

			var model = this._mediator.Send(new SelectAllSelfiesQuery() { UserId = userId });

			return this.Ok(model);
		}

		//[HttpGet("{id}")]
		//public IActionResult GetValue(int id, string version)
		//{
		//	var value = $"Value {id} of version {version}";
		//	return Ok(value);
		//}

		//[Route("pictures")]
		//[HttpPost]
		//public async Task<IActionResult> AddPicture()
		//{
		//	using var stream = new StreamReader(this.Request.Body);

		//	var content = await stream.ReadToEndAsync();

		//	return this.Ok();
		//}

		[Route("pictures")]
		[HttpPost]
		public async Task<IActionResult> AddPicture(IFormFile picture)
		{
			const string relativeFilepath = @"images\selfies";
			string filePath = Path.Combine(this._webHostEnvironement.ContentRootPath, relativeFilepath);

			if (!Directory.Exists(filePath))
			{
				Directory.CreateDirectory(filePath);
			}

			filePath = Path.Combine(filePath, picture.FileName);
			
			using FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);
			await picture.CopyToAsync(stream);

			var itemFile = this._repository.AddOnePicture(Path.Combine(relativeFilepath, picture.FileName));

			try
			{
				this._repository.UnitOfWork.SaveChanges();
			}
			catch (Exception exception)
			{
				Console.Out.Write(exception.Message);
				throw;
			}

			return this.Ok(itemFile);
		}

		[HttpPost]
		public async Task<IActionResult> AddOne(SelfieDTO selfieDto)
		{
			IActionResult result = this.BadRequest();

			var selfieResult = await this._mediator.Send(new AddSelfieCommand() { SelfieDto = selfieDto });
			if (selfieResult != null)
			{
				result = this.Ok(selfieResult);
			}

			return result;
		}
		#endregion//Public methods
	}
}
