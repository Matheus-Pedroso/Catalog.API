using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebUI.Controllers;

public class CategoryController(ICategoryService categoryService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await categoryService.GetCategories();
        return View(categories);
    }
}
