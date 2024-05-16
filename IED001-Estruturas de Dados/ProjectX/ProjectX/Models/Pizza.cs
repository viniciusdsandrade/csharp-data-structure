using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Models
{
    public class Pizza
    {
        public int IdPizza { get; set; }
        public string Nome { get; set; }
        public string Ingredientes { get; set; }
        public int Valor { get; set; }
    }
}
