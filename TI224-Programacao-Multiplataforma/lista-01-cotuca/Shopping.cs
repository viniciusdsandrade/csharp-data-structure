using System;
using System.Text;

namespace Shopping
{
    public class Invoice
    {
        private readonly int id;
        private readonly Customer customer;
        private readonly List<Product> products = [];
        private readonly List<int> quantities = [];
        private readonly int nProducts = 0;

        public Invoice(int id, Customer customer)
        {
            this.id = id;
            this.customer = customer;
        }

        public bool AddProduct(Product product, int amount)
        {
            if (products.Count == quantities.Count)
            {
                products.Add(product);
                quantities.Add(amount);
                return true;
            }

            return false;
        }

        public bool RemoveProduct(Product product)
        {
            int index = products.IndexOf(product);
            if (index != -1)
            {
                products.RemoveAt(index);
                quantities.RemoveAt(index);
                return true;
            }

            return false;
        }

        public double GetTotal()
        {
            double total = 0.0;
            for (int i = 0; i < products.Count; i++)
            {
                total += products[i].GetPrice() * quantities[i];
            }
            return total;
        }

        public double GetTotalAfterDiscount() => GetTotal() * (1 - customer.GetDiscount() / 100);  

        public override int GetHashCode()
        {
            unchecked
            {
                const int prime = 31;
                int hash = 1;

                hash = hash * prime + id.GetHashCode();
                hash = hash * prime + customer.GetHashCode();

                foreach (var product in products)
                {
                    hash = hash * prime + product.GetHashCode();
                }

                foreach (var quantity in quantities)
                {
                    hash = hash * prime + quantity.GetHashCode();
                }

                if (hash < 0) _ = -hash;
                
                return hash;
            }
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            Invoice that = (Invoice)obj;

            if (id != that.id || nProducts != that.nProducts) return false;
            
            if (id != that.id || nProducts != that.nProducts || !customer.Equals(that.customer))
            {
                return false;
            }

            for (int i = 0; i < nProducts; i++)
            {
                if (!products[i].Equals(that.products[i]) || quantities[i] != that.quantities[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString() => $"Invoice [id = {id}, customer = {customer}, products = {string.Join(", ", products)}, quantities = {string.Join(", ", quantities)}]";
    }

    public class Customer
    {
        private readonly int id;
        private readonly string name;
        private int discount = 0;

        public Customer(int id, string name, int discount)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty");

            if (discount < 0 || discount > 100)
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
            if (discount < 0 || discount > 100)
            {
                throw new ArgumentException("Discount must be between 0 and 100");
            }

            this.discount = discount;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime + id;
            hash *= prime + name.GetHashCode();
            hash *= prime + discount.GetHashCode();

            if (hash < 0) _ = -hash;

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
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty");

            if (price < 0.0)
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
            if (price < 0.0)
            {
                throw new ArgumentException("Price cannot be negative");
            }

            this.price = price;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime + id;
            hash *= prime + name.GetHashCode();
            hash *= prime + price.GetHashCode();

            if (hash < 0) _ = -hash;
            
            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            Product that = (Product) obj;
    
            return Equals(this.id, that.id) && 
                Equals(this.name, that.name) && 
                Equals(this.price, that.price);
        }

        public override string ToString() => "Product[id = " + id + ", name = " + name + ", price = " + price + "]";
    }
}