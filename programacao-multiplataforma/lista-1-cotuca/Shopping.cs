using System;

namespace Shopping
{
    public class Invoice
    {
        private readonly int id;
        private readonly Customer customer;
        private int nProducts = 0;
        private Product[] products = [];
        private int[] quantities = [];

        public Invoice(int id, Customer customer)
        {
            this.id = id;
            this.customer = customer;
        }

        public bool AddProduct(Product product, int amount)
        {
            if (nProducts == products.Length)
            {
                return false;
            }

            products[nProducts] = product;
            quantities[nProducts] = amount;
            nProducts++;

            return true;
        }

        public bool RemoveProduct(Product product)
        {
            for (int i = 0; i < nProducts; i++)
            {
                if (products[i].Equals(product))
                {
                    for (int j = i; j < nProducts - 1; j++)
                    {
                        products[j] = products[j + 1];
                        quantities[j] = quantities[j + 1];
                    }

                    nProducts--;
                    return true;
                }
            }

            return false;
        }

        public double GetTotal()
        {
            double total = 0.0;

            for (int i = 0; i < nProducts; i++)
            {
                total += products[i].GetPrice() * quantities[i];
            }

            return total - total * customer.GetDiscount() / 100;
        }

        public double GetTotalAfterDiscount()
        {
            return GetTotal() - GetTotal() * customer.GetDiscount() / 100;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime + id;
            hash *= prime + customer.GetHashCode();
            hash *= prime + nProducts;

            for (int i = 0; i < nProducts; i++)
            {
                hash *= prime + products[i].GetHashCode();
                hash *= prime + quantities[i].GetHashCode();
            }

            if (hash < 0)
            {
                hash = -hash;
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Invoice that = (Invoice)obj;

            if (id != that.id || nProducts != that.nProducts)
            {
                return false;
            }

            if (!customer.Equals(that.customer))
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

        public override string ToString()
        {
            string invoice = "Invoice [id = " + id + ", customer = " + customer + ", products = [";

            for (int i = 0; i < nProducts; i++)
            {
                invoice += products[i] + ", quantity = " + quantities[i] + ", ";
            }

            invoice += "]]";

            return invoice;
        }
    }

    public class Customer
    {
        private readonly int id;
        private readonly string name;
        private int discount;

        public Customer(int id, string name, int discount)
        {
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

            if (hash < 0)
            {
                _ = -hash;
            }

            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Customer that = (Customer)obj;

            return Equals(this.id, that.id) &&
                Equals(this.name, that.name) &&
                Equals(this.discount, that.discount);
        }

        public override string ToString() => "Customer [id = " + id + ", name = " + name + ", discount = " + discount + "]";

    }

    public class  Product 
    {
        private readonly int id;
        private readonly string name;
        private double price;

        public Product(int id, string name, double price)
        {
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

            if (hash < 0)
            {
                _ = -hash;
            }

            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Product that = (Product)obj;

           
            return Equals(this.id, that.id) && 
                Equals(this.name, that.name) && 
                Equals(this.price, that.price);
        }

        public override string ToString() => "Product [id = " + id + ", name = " + name + ", price = " + price + "]";
    }
}