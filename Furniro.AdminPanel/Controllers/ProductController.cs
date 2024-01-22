using Application.CategoryDetails.Commands.Request;
using Application.CategoryDetails.Queries.Request;
using Application.ProductDetails.Commands.Request;
using Application.ProductDetails.Queries.Request;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YourProjectNamespace.Services;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMediator _mediator;
        private readonly ProductExportService _productExportService;

        public ProductController(IMediator mediator, ProductExportService productExportService, AppDbContext dbContext)
        {
            _mediator = mediator;
            _productExportService = productExportService;
            _dbContext = dbContext;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(response); 
            }

            return BadRequest(response); 
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return response != null
           ? (IActionResult)Ok(response)
           : NotFound(new { Message = "Product not found." });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Product updated successfully." });
            }

            return BadRequest(new { Message = "Product update failed." });
        }

        [HttpPut("update/ProductImages")]
        public async Task<IActionResult> UpdateProductImage([FromForm] UpdateProductColorImageRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Product updated successfully." });
            }

            return BadRequest(new { Message = "Product update failed." });
        }

        [HttpPut("update/DescriptionImages")]
        public async Task<IActionResult> UpdateDescriptionImage([FromForm] UpdateDescriptionImageRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Description updated successfully." });
            }

            return BadRequest(new { Message = "Description update failed." });
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetProductById([FromQuery] GetByIdProductQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return response != null
                ? (IActionResult)Ok(response)
                : NotFound(new { Message = "Product not found." });
        }

        [HttpGet("export-to-excel")]
        public async Task<IActionResult> ExportProductsToExcel()
        {
            var products = await _dbContext.Products
            .Include(p => p.Category) 
            .Include(p => p.Description) 
            .ToListAsync();

            var excelData = await _productExportService.ExportProductsToExcelAsync(products);

            return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Products.xlsx");
        }
    }
}
