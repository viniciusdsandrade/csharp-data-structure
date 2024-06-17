using System.ComponentModel.DataAnnotations;

namespace ti224_prova2.Models;

public class Customer
{
    [Key] public int CustomerId { get; set; }
    [Required, StringLength(50)] public string? Name { get; set; }
    [Required, StringLength(100)] public string? Address { get; set; }
    [Required, StringLength(50)] public string? City { get; set; }
    [Required, StringLength(30)] public string? State { get; set; }
    [Required, StringLength(13)] public string? PostalCode { get; set; }

    public ICollection<SalesOrder>? SalesOrders { get; set; }
}