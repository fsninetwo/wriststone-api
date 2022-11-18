using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wriststone.Wriststone.API.Attributes;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService, 
            IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            _productService = productService;
        }

        [HttpGet]
        [DisableTokenValidation]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet]
        [DisableTokenValidation]
        public async Task<IActionResult> GetProducts(string search)
        {
            var products = await _productService.GetProductsAsync(search);

            return Ok(products);
        }
    }
}
