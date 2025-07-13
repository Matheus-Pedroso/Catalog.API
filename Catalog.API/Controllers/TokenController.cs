using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Catalog.Application.DTOs.Models;
using Catalog.Application.Interfaces;
using Catalog.Domain.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController(IAuthenticate authenticate, IConfiguration configuration, ITokenService tokenService) : ControllerBase
{
    [HttpPost("LoginUser")]
    public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel model)
    {
        if (model == null)
        {
            return BadRequest("Invalid client request");
        }

        var userToken = await authenticate.Authenticate(model.Email, model.Password);

        if (userToken)
            return tokenService.GenerateToken(model);

        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return BadRequest(ModelState);
        }
    }
}
