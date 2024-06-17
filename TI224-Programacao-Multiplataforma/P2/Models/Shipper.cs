using System.ComponentModel.DataAnnotations;

namespace ti224_prova2.Models;

public class Shipper
{
    [Key] public int ShipperId { get; set; }
    [Required, StringLength(50)] public string? Name { get; set; }

    public ICollection<SalesOrder>? SalesOrders { get; set; }
}