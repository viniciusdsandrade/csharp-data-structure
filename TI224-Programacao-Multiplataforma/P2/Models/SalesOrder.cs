using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ti224_prova2.Models;

public class SalesOrder
{
    [Key] public int SalesOrderId { get; set; }
    [Required] public DateTime OrderDate { get; set; }
    public DateTime? EstimatedDeliveryDate { get; set; }

    [Required, Precision(11, 5)] public decimal Freight { get; set; }
    [Required, Precision(11, 5)] public decimal Total { get; set; }

    [ForeignKey("Customer")] [Required] public int CustomerId { get; set; }
    [ForeignKey("Employee")] [Required] public int EmployeeId { get; set; }
    [ForeignKey("Shipper")] [Required] public int ShipperId { get; set; }

    public Customer? Customer { get; set; }
    public Employee? Employee { get; set; }
    public Shipper? Shipper { get; set; }

    public ICollection<SalesOrderItem>? SalesOrderItems { get; set; }

    public bool AddItem(SalesOrderItem? item)
    {
        if (item == null) return false;

        SalesOrderItems ??= new List<SalesOrderItem>();
        SalesOrderItems.Add(item);
        CalculateSalesOrderTotal(); // Recalcula o total
        return true;
    }

    public bool RemoveItem(int itemId)
    {
        var itemToRemove = SalesOrderItems?.FirstOrDefault(i => i.SalesOrderId == itemId);
        if (itemToRemove == null) return false;

        SalesOrderItems?.Remove(itemToRemove);
        CalculateSalesOrderTotal(); // Recalcula o total
        return true;
    }

    private decimal CalculateSalesOrderTotal()
    {
        if (SalesOrderItems == null || SalesOrderItems.Count == 0)
        {
            Total = Freight;
            return Total;
        }

        Total = SalesOrderItems.Sum(i => (i.UnitPrice * i.Quantity) * (1 - i.Discount));
        Total += Freight;
        return Total;
    }
}