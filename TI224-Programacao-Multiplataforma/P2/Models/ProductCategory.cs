using System.ComponentModel.DataAnnotations;

namespace ti224_prova2.Models;

public class ProductCategory
{
    [Key] public int ProductCategoryId { get; set; }

    [Required] [MaxLength(50)] public string? Name { get; set; }
    [Required] [MaxLength(200)] public string? Description { get; set; }

    public ICollection<Product>? Products { get; set; }
}