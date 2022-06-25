using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public StoreContext Context { get; }

        public ProductsController(StoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            var products = await Context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            return await Context.Products.FindAsync(id);
        }
    }
}