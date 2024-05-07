using System;
using Microsoft.EntityFrameworkCore;

namespace Models
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{

		}

		public DbSet<Produto> Produtos { get; set; }
	}
}