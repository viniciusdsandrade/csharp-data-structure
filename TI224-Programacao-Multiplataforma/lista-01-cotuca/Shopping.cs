namespace Shopping
{
    public class Invoice
    {
        private readonly int id;
        private readonly Customer customer;
        private readonly List<Product> products = [];
        private readonly List<int> quantities = [];
        private int nProducts = 0;

        public Invoice(int id, Customer customer)
        {
            this.id = id;
            this.customer = customer;
        }

        public bool AddProduct(Product product, int amount)
        {
            if (nProducts >= 30) return false; 
            
            products.Add(product);
            quantities.Add(amount);
            nProducts++;
            return true;
        }

        public bool RemoveProduct(Product product)
        {
            int index = products.IndexOf(product);
            if (index != -1)
            {
                products.RemoveAt(index);
                quantities.RemoveAt(index);
                nProducts--;
                return true;
            }

            return false;
        }

        public double GetTotal()
        {
            double total = 0.0;

            for (int i = 0; i < products.Count; i++)
                total += products[i].GetPrice() * quantities[i];
            
            return total;
        }

        public double GetTotalAfterDiscount() => GetTotal() * (1 - customer.GetDiscount() / 100);

        public override int GetHashCode()
        {
                const int prime = 31;
                int hash = 1;

                hash *= prime + id.GetHashCode();
                hash *= prime + customer.GetHashCode();

                foreach (var product in products)
                    hash *= prime + product.GetHashCode();

                foreach (var quantity in quantities)
                    hash *= prime + quantity.GetHashCode();
                

                if (hash < 0) hash = -hash;

                return hash;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            Invoice that = (Invoice)obj;
            
            return Object.Equals(this.id, that.id) &&
                Object.Equals(this.customer, that.customer) &&
                Array.Equals(this.products, that.products) &&
                Array.Equals(this.quantities, that.quantities);
        }

        public override string ToString() => "Invoice [id = " + id + ", customer = " + customer + ", total = " + GetTotal() + "]";
    }

    public class Customer
    {
        private readonly int id;
        private readonly string name;
        private int discount = 0;

        public Customer(int id, string name, int discount)
        {
            if (!Int128.IsPositive(id))
                throw new ArgumentException("ID must be a positive integer.", nameof(id));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty");

            if (Int128.IsNegative(discount) || discount > 100)
                throw new ArgumentException("Discount must be between 0 and 100");

            this.id = id;
            this.name = name;
            this.discount = discount;
        }

        public int GetId() => id;
        public string GetName() => name;
        public int GetDiscount() => discount;
        public void SetDiscount(int discount)
        {
            if (Int128.IsNegative(discount) || discount > 100)
                throw new ArgumentException("Discount must be between 0 and 100");
            
            this.discount = discount;
        }
        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime + id;
            hash *= prime + name.GetHashCode();
            hash *= prime + discount.GetHashCode();

            if (hash < 0) hash = -hash;

            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            Customer that = (Customer)obj;

            return Equals(this.id, that.id) &&
                Equals(this.name, that.name) &&
                Equals(this.discount, that.discount);
        }

        public override string ToString() => "Customer [id = " + id + ", name = " + name + ", discount = " + discount + "]";
    }

    public class Product
    {
        private readonly int id;
        private readonly string name;
        private double price;

        public Product(int id, string name, double price)
        {
            if (!Int128.IsPositive(id))
                throw new ArgumentException("ID must be a positive integer.", nameof(id));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty");

            if (double.IsNegative(price))
                throw new ArgumentException("Price cannot be negative");

            this.id = id;
            this.name = name;
            this.price = price;
        }

        public int GetId() => id;
        public string GetName() => name;
        public double GetPrice() => price;
        public void SetPrice(double price)
        {
            if (double.IsNegative(price))
                throw new ArgumentException("Price cannot be negative");

            this.price = price;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime + id;
            hash *= prime + name.GetHashCode();
            hash *= prime + price.GetHashCode();

            if (hash < 0) hash = -hash;

            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            Product that = (Product)obj;

            return Equals(this.id, that.id) &&
                Equals(this.name, that.name) &&
                Equals(this.price, that.price);
        }

        public override string ToString() => "Product[id = " + id + ", name = " + name + ", price = " + price + "]";
    }
}