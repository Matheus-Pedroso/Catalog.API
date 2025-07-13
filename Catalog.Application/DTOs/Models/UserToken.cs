namespace Catalog.Application.DTOs.Models;

public class UserToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
