using System;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.Controllers.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            return Ok(await _service.GetCategoriesAsync());
        }
    }
}