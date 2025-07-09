using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebUI.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid format email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", MinimumLength = 10)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public string ReturnUrl { get; set; } = string.Empty;
}
