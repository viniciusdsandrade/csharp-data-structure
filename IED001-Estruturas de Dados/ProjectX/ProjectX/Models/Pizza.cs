namespace ProjectX.Models
{
    public class Pizza
    {
        public int IdPizza { get; init; }
        public string? Nome { get; init; }
        public string? Ingredientes { get; init; }
        public int Valor { get; init; }

        public string? GetNome() => Nome;
        public string? GetIngredientes() => Ingredientes;
        public int GetValor() => Valor;
        public int GetIdPizza() => IdPizza;

        public Pizza(int idPizza, string? nome, string? ingredientes, int valor)
        {
            IdPizza = idPizza;
            Nome = nome;
            Ingredientes = ingredientes;
            Valor = valor;
        }

        public Pizza()
        {
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            
            var pizza = (Pizza)obj;
            
            return IdPizza == pizza.IdPizza &&
                   Nome == pizza.Nome &&
                   Ingredientes == pizza.Ingredientes &&
                   Valor == pizza.Valor;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            var hash = 1;

            hash *= prime + IdPizza;
            hash *= prime + (Nome == null ? 0 : Nome.GetHashCode());
            hash *= prime + (Ingredientes == null ? 0 : Ingredientes.GetHashCode());
            hash *= prime + Valor;

            if (hash < 0) hash = -hash;

            return hash;
        }
    }
}