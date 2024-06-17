using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ti224_prova2.Context;
using ti224_prova2.Models;

namespace ti224_prova2.Controllers;

[ApiController]
[Route("/products/categories")]
public class ProductCategoryController(ApplicationDatabaseContext context) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<ProductCategory>> GetProductCategories()
        => context.ProductCategories.ToList();

    [HttpGet("{id:int}")]
    public ActionResult<ProductCategory> GetProductCategory(int id)
    {
        var productCategory = context.ProductCategories.Find(id);
        if (productCategory == null) return NotFound();
        return productCategory;
    }

    [HttpPost]
    public ActionResult<ProductCategory> PostProductCategory(ProductCategory productCategory)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        context.ProductCategories.Add(productCategory);
        context.SaveChanges();

        return CreatedAtAction(nameof(GetProductCategory), new { id = productCategory.ProductCategoryId },
            productCategory);
    }

    [HttpPut("{id:int}")]
    public IActionResult PutProductCategory(int id, ProductCategory productCategory)
    {
        if (id != productCategory.ProductCategoryId) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);
        context.Entry(productCategory).State = EntityState.Modified;

        try
        {
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductCategoryExists(id))
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

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProductCategory(int id)
    {
        var productCategory = context.ProductCategories.Find(id);
        if (productCategory == null) return NotFound();
        context.ProductCategories.Remove(productCategory);
        context.SaveChanges();
        return NoContent();
    }

    private bool ProductCategoryExists(int id) => context.ProductCategories.Any(e => e.ProductCategoryId == id);
}