using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Service_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ProductsInfoeController : ControllerBase
    {
        private readonly ProductCatalogContext _context;

        public ProductsInfoeController(ProductCatalogContext context)
        {
            _context = context;
        }

        // GET: api/ProductsInfoe
        [HttpGet("/getall")]
        public async Task<ActionResult<IEnumerable<ProductsInfo>>> GetProductsInfos()
        {
            return await _context.ProductsInfos.ToListAsync();
        }

        // GET: api/ProductsInfoe/5
        [HttpGet("/getone/{id}")]
        public async Task<ActionResult<ProductsInfo>> GetProductsInfo(int id)
        {
            var productsInfo = await _context.ProductsInfos.FindAsync(id);

            if (productsInfo == null)
            {
                return NotFound();
            }

            return productsInfo;
        }

        // PUT: api/ProductsInfoe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/update/{id}")]
        public async Task<IActionResult> PutProductsInfo(int id, ProductsInfo productsInfo)
        {
            if (id != productsInfo.ProductRowId)
            {
                return BadRequest();
            }

            _context.Entry(productsInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductsInfoe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/create")]
        public async Task<ActionResult<ProductsInfo>> PostProductsInfo(ProductsInfo productsInfo)
        {
            _context.ProductsInfos.Add(productsInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductsInfo", new { id = productsInfo.ProductRowId }, productsInfo);
        }

        // DELETE: api/ProductsInfoe/5
        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> DeleteProductsInfo(int id)
        {
            var productsInfo = await _context.ProductsInfos.FindAsync(id);
            if (productsInfo == null)
            {
                return NotFound();
            }

            _context.ProductsInfos.Remove(productsInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsInfoExists(int id)
        {
            return _context.ProductsInfos.Any(e => e.ProductRowId == id);
        }
    }
}
