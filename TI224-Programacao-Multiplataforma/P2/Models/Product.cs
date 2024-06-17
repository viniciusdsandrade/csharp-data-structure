using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ti224_prova2.Models;

public class Product
{
    [Key] public int ProductId { get; set; }

    [Required] [MaxLength(50)] public string? Name { get; set; }
    [Required] [MaxLength(200)] public string? Description { get; set; }

    [Required] [Precision(11, 5)] public decimal UnitPrice { get; set; }
    public ICollection<SalesOrderItem>? SalesOrderItems { get; set; }

    [Required]
    [ForeignKey("ProductCategory")]
    public int ProductCategoryId { get; set; }
    public ProductCategory? ProductCategory { get; set; }
}