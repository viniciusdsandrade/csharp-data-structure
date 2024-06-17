using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ti224_prova2.Models;

namespace ti224_prova2.Context;

public class ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options)
    : DbContext(options)
{
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.HasDefaultSchema("db_prova_2");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;Database=db_prova_2;Uid=root;Pwd=GhostSthong567890@",
                ServerVersion.AutoDetect("Server=localhost;Database=db_catalog_api;Uid=root;Pwd=GhostSthong567890@"),
                options => options.SchemaBehavior(MySqlSchemaBehavior.Ignore)
            );
        }
    }
}