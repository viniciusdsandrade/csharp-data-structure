using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ti224_prova2.Context;
using ti224_prova2.Models;

namespace ti224_prova2.Controllers;

[ApiController]
[Route("/products")]
public class ProductController(ApplicationDatabaseContext context) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return context.Products
            .Include(p => p.ProductCategory) // Inclui a categoria do produto
            .ToList();
    }

    [HttpGet("{id:int}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = context.Products
            .Include(p => p.ProductCategory) // Inclui a categoria do produto
            .FirstOrDefault(m => m.ProductId == id);
        if (product == null) return NotFound();
        return product;
    }

    [HttpPost]
    public ActionResult<Product> PostProduct(Product product)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        context.Products.Add(product);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
    }

    [HttpPut("{id:int}")]
    public IActionResult PutProduct(int id, Product product)
    {
        if (id != product.ProductId) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);

        context.Entry(product).State = EntityState.Modified;

        try
        {
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = context.Products.Find(id);
        if (product == null) return NotFound();
        context.Products.Remove(product);
        context.SaveChanges();
        return NoContent();
    }

    private bool ProductExists(int id) => context.Products.Any(e => e.ProductId == id);
}