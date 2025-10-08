using Day1.Data;
using Day1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _service;


        public ProductController(IProductService service)
        {
            _service = service;
        }


        //[HttpPost]
        //public async Task<ActionResult<Product>> CreateProduct(Product product)
        //{
        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _service.GetAll();

            return Ok(products);
        }


        //[HttpGet]
        //public async Task<ActionResult<Product>> GetProd([FromQuery] int id)
        //{
        //    var product = await _context.Products.FindAsync(id);

        //    return Ok(product);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);

        //    return Ok(product);
        //}


        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Product>> DeleteProduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);

        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, Product p)
        //{
        //    var product = await _context.Products.FindAsync(id);

        //    _context.Products.Update(product);

        //    product.Name = p.Name;
        //    product.Price = p.Price;

        //    await _context.SaveChangesAsync();

        //    return Ok(product);
        //}


    }
}
