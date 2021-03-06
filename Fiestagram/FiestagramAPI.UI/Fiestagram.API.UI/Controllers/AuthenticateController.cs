using Fiestagram.API.UI.Application.DTOs;
using Fiestagram.Core.Selfies.Infrastructure.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fiestagram.API.UI.Controllers
{
	/// <summary>
	/// User login controller
	/// </summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	public class AuthenticateController : ControllerBase
	{
		#region Fields
		// Holds the authentication information and helper of all user credentials
		private readonly UserManager<IdentityUser> _userManager = null;
		private readonly SecurityOption _securityOption = null;
		private ILogger<AuthenticateController> _logger = null;
		#endregion//Fields

		#region Constructors
		public AuthenticateController(ILogger<AuthenticateController> logger, UserManager<IdentityUser> userManager, IOptions<SecurityOption> securityOption)
		{
			this._userManager = userManager;
			this._securityOption = securityOption.Value;
			this._logger = logger;

			this._logger.LogDebug("Authentication controller constructor call");
		}
		#endregion//Constructors

		#region Public methods
		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> Register([FromBody] AuthenticateUserDto dtoUser)
		{
			IActionResult result = this.BadRequest();

			IdentityUser user = new IdentityUser(dtoUser.Login);
			user.Email = dtoUser.Login;
			user.UserName = dtoUser.Name;
			var userCreationTask = await _userManager.CreateAsync(user);

			if (userCreationTask.Succeeded)
			{
				dtoUser.Token = this.GenerateJwtToken(user);
				result = this.Ok(dtoUser);
			}

			return result;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Login([FromBody] AuthenticateUserDto dtoUser)
		{
			IActionResult result = this.BadRequest();

			try
			{
				var user = await this._userManager.FindByEmailAsync(dtoUser.Login);
				if (user != null)
				{
					//var passwordCheckPass = await this._userManager.CheckPasswordAsync(user, dtoUser.Password);
					//if (passwordCheckPass)
					//{
					result = this.Ok(new AuthenticateUserDto()
					{
						Login = user.Email,
						Name = user.UserName,
						Token = this.GenerateJwtToken(user)
					});
					//}
				}
			}
			catch (Exception exception)
			{
				this._logger.LogError("Login", exception, dtoUser);
				result = this.Problem("Cannot log");
			}

			return result;
		}
		#endregion//Public methods

		#region Internal Methods
		private string GenerateJwtToken(IdentityUser user)
		{
			// Now its time to define the Jwt token which will be responsible of creating our tokens
			var jwtTokenHandler = new JwtSecurityTokenHandler();

			// We get our secret from the appsettings.json
			var key = Encoding.UTF8.GetBytes(this._securityOption.Key);

			/***
			 * We define our token descriptor
			 * We need to use claims which are properties in our token which gives information about the token
			 * which belong to the specific user who it belongs to
			 * so it could contain their id, name, email the good part is that these information
			 * are generated by our server and identity framework which is valid and trusted
			 ***/
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
				new Claim("Id", user.Id),
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
                // the JTI is used for our refresh token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			}),
				// the life span of the token needs to be shorter and use refresh token to keep the user signed in
				// but since this is a demo app we can extend it to fit our current need
				Expires = DateTime.UtcNow.AddHours(6),
				// here we are adding the encryption algorithm information which will be used to decrypt our token
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
			};

			var token = jwtTokenHandler.CreateToken(tokenDescriptor);

			var jwtToken = jwtTokenHandler.WriteToken(token);

			return jwtToken;
		}
		#endregion//Internal Methods
	}
}
