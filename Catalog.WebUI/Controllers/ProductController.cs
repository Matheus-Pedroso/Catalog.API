using System.Runtime.CompilerServices;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Catalog.WebUI.Controllers;

public class ProductController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment env) : Controller
{

    #region VIEWS   
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await productService.GetProducts();
        return View(products);
    }

    [HttpGet()]
    public async Task<IActionResult> Create()
    {
        ViewBag.CategoryId = new SelectList(await categoryService.GetCategories(), "Id", "Name");

        return View();
    }

    [HttpGet()]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await productService.GetById(id);
        if (product == null) return NotFound();
        ViewBag.CategoryId = new SelectList(await categoryService.GetCategories(), "Id", "Name", product.CategoryId);
        return View(product);
    }

    [Authorize(Roles = "Admin")] // User need to be in Admin role and Authenticated to access this action
    [HttpGet()]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await productService.GetById(id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpGet()]
    public async Task<IActionResult> Details(int id)
    {
        var product = await productService.GetById(id);
        if (product == null)
            return NotFound();

        var wwwroot = env.WebRootPath;
        var imagePath = Path.Combine(wwwroot, "images\\" + product.Image);
        var exists = System.IO.File.Exists(imagePath);
        ViewBag.ImageExist = exists;

        return View(product);
    }
    #endregion

    [HttpPost]
    public async Task<IActionResult> Create(ProductDTO product)
    {
        if (!ModelState.IsValid) return View(product);

        await productService.Add(product);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDTO product)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await productService.Update(product);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }
        return View(product);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(ProductDTO product)
    {
        await productService.Delete(product.Id);
        return RedirectToAction(nameof(Index));
    }
}
