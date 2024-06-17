using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ti224_prova2.Models;

public class Employee
{
    [Key] public int EmployeeId { get; set; }

    [Required, StringLength(50)] public string? Name { get; set; }
    [Required] public DateTime BirthDate { get; set; }
    [Required] public DateTime HireDate { get; set; }
    [Required, StringLength(100)] public string? Address { get; set; }
    [Required, StringLength(50)] public string? City { get; set; }
    [Required, StringLength(30)] public string? State { get; set; }
    [Required, StringLength(13)] public string? PostalCode { get; set; }

    [ForeignKey("ReportsToEmployee")] public int? ReportsTo { get; set; }
    public Employee? ReportsToEmployee { get; set; }
    public ICollection<Employee>? Subordinates { get; set; }
    public ICollection<SalesOrder>? SalesOrders { get; set; }

    public decimal CalculateSalesComission(decimal comissionRate = 0.05m)
    {
        // Verifica se o funcionário possui pedidos associados
        if (SalesOrders == null || SalesOrders.Count == 0)
        {
            return 0.0m;
        }

        // Calcula a comissão com base na taxa de comissão (padrão de 5%)
        var totalSales = SalesOrders.Sum(o => o.Total);
        var comission = totalSales * comissionRate;
        return comission;
    }
}