using Assignment.Services.ViewModels.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Assignment.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{

		[Route("login")]
		[HttpPost]
		public IActionResult Post([FromBody] LoginRequestModel loginRequest)
		{
			try
			{
				if (ModelState.IsValid)
				{
					if (loginRequest.UserName == "EndUser" && loginRequest.Password == "EndUser@123")
					{
						//for now hardcoding the values
						//all configurable values should be placed in appsettings or environment variables.
						//all secrets should be placed in vault or other secret manager.
						var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("productstoresecret"));
						var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
						var tokeOptions = new JwtSecurityToken(issuer: "http://localhost:5199", audience: "http://localhost:5199", claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(600), signingCredentials: signinCredentials);
						var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
						return Ok(new JWTTokenResponse
						{
							Token = tokenString
						});
					}
					return BadRequest("Invalid User Credentails, please try again with valid ones !!");
				}
				else
					return BadRequest(ModelState);

			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
