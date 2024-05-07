using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	[Table("tb_produto")]
	public class Produto
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("nome")]
		public string Nome { get; set; }

		[Column("preco")]
		public decimal Preco { get; set; }
	}
}
