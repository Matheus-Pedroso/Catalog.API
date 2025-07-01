using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebUI.Controllers;

public class ProductController(IProductService productService) : Controller
{

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await productService.GetProducts();
        return View(products);
    }
}
