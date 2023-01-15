using System;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.Controllers.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            return Ok(await _service.GetProducts());
        }
    }
}