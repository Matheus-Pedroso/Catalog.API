using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebUI.Controllers;

[Authorize]
public class CategoryController(ICategoryService categoryService) : Controller
{
    #region Views
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await categoryService.GetCategories();
        return View(categories);
    }
    [HttpGet()]
    public async Task<IActionResult> Details(int id)
    {
        if (id == 0) return NotFound();
        var category = await categoryService.GetById(id);
        if (category is null) return NotFound();
        return View(category);
    }
    [HttpGet()]
    public async Task<IActionResult> Create() => View();
    [HttpGet()]
    public async Task<IActionResult> Edit(int id)
    {
        if (id == 0) return NotFound();

        var category = await categoryService.GetById(id);
        if (category is null) return NotFound();

        return View("Update", category);
    }
    [HttpGet()]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == 0) return NotFound();
        var category = await categoryService.GetById(id);
        if (category is null) return NotFound();
        return View(category);
    }
    #endregion



    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO request)
    {
        if (ModelState.IsValid)
        {
            await categoryService.Add(request);
            return RedirectToAction(nameof(Index));
        }
        return View(request);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDTO request)
    {
        if (ModelState.IsValid)
        {
            try
            { 
                await categoryService.Update(request);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View("Update", request);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (id == 0) return NotFound();
        await categoryService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
