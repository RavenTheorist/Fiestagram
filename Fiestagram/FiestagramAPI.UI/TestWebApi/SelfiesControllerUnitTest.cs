using Fiestagram.API.UI.Controllers;
using Fiestagram.Core.Framework;
using Fiestagram.Core.Selfies.Domain;
using FiestagramAPI.UI.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestWebApi
{
	public class SelfiesControllerUnitTest
	{
		[Fact]
		public void ShouldAddOneSelfie()
		{
			// ARRANGE
			//SelfieDTO selfieDto = new SelfieDTO();
			//Mock<ISelfieRepository> repositoryMock = new Mock<ISelfieRepository>();
			//Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
			//repositoryMock.Setup(item => item.UnitOfWork).Returns(unitOfWork.Object);
			//repositoryMock.Setup(item => item.AddOne(It.IsAny<Selfie>())).Returns(new Selfie() { Id = 4 });

			//// ACT
			//var controller = new SelfiesController(repositoryMock.Object);
			//IActionResult result = controller.AddOne(selfieDto);

			//// ASSERT
			//Assert.NotNull(result);
			//Assert.IsType<OkObjectResult>(result);

			//SelfieDTO addedSelfie = (result as OkObjectResult).Value as SelfieDTO;
			//Assert.NotNull(addedSelfie);
			//Assert.True(addedSelfie.Id > 0);
		}

		[Fact]
		public void TesterMaMethodeGet()
		{
			// ARRANGE
			//List<Selfie> expectedSelfiesList = new List<Selfie>()
			//{
			//	new Selfie() { Id = 1, User = new User() },
			//	new Selfie() { Id = 2, User = new User() }
			//};

			//Mock<ISelfieRepository> repositoryMock = new Mock<ISelfieRepository>();
			//repositoryMock.Setup(item => item.GetAll(It.IsAny<int>())).Returns(expectedSelfiesList);

			//SelfiesController controller = new SelfiesController(repositoryMock.Object);

			//// ACT
			//IActionResult result = controller.GetAll();

			//// ASSERT
			//Assert.NotNull(result);
			//Assert.IsType<OkObjectResult>(result);

			//OkObjectResult okResult = result as OkObjectResult;

			//Assert.NotNull(okResult.Value);
			//Assert.IsType<List<SelfieResumeDTO>>(okResult.Value);

			//List<SelfieResumeDTO> list = okResult.Value as List<SelfieResumeDTO>;
			//Assert.True(list.Count == expectedSelfiesList.Count);
		}
	}
}
