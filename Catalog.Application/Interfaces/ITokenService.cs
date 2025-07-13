using Catalog.Application.DTOs.Models;

namespace Catalog.Application.Interfaces;

public interface ITokenService
{
    UserToken GenerateToken(LoginModel model);
}
