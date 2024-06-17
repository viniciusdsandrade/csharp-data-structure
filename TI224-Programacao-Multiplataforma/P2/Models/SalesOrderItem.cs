using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ti224_prova2.Models;

public class SalesOrderItem
{
    [ForeignKey("SalesOrder")] public int SalesOrderId { get; set; }
    [ForeignKey("Product")] public int ProductId { get; set; }

    [Required] public int Quantity { get; set; }
    [Required, Precision(11, 5)] public decimal UnitPrice { get; set; }
    [Required, Precision(11, 5)] public decimal Discount { get; set; }

    [Key] public SalesOrder? SalesOrder { get; set; }
    public Product? Product { get; set; }
}