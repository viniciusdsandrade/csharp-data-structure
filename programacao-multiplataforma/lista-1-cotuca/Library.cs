using System;

namespace Library
{
    public class Book
    {
        private readonly string name;
        private readonly Author author;
        private double price;
        private int quantity = 0;

        public Book(string name, Author author, double price)
        {
            this.name = name;
            this.author = author;
            this.price = price;
        }

        public Book(string name, Author author, double price, int quantiyty)
        {
            this.name = name;
            this.author = author;
            this.price = price;
            this.quantity = quantiyty;
        }

        public string GetName()
        {
            return name;
        }

        public Author GetAuthor()
        {
            return author;
        }

        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime + ((name == null) ? 0 : name.GetHashCode());
            hash *= prime + ((author == null) ? 0 : author.GetHashCode());
            hash *= prime + ((price == null) ? 0 : price.GetHashCode());
            hash *= prime + ((quantity == null) ? 0 : quantity.GetHashCode());

            if (hash < 0) hash = -hash;

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

            Book that = (Book)obj;

            return Equals(this.name, that.name) && 
                Equals(this.author, that.author) && 
                Equals(this.price, that.price) && 
                Equals(this.quantity, that.quantity);
        }

        public override string ToString()
        {
            return "Book[name = " + name + ", " + author + ", price = " + price + ", quantity = " + quantity + "]";
        }
    }
    public class Author
    {
        private readonly string name;
        private string email;
        private readonly char gender;

        public Author(string name, string email, char gender)
        {
            this.name = name;
            this.email = email;
            if(gender == 'M' || gender == 'F')
            {
                this.gender = gender;
            }
        }

        public string GetName()
        {
            return name;
        }

        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public char GetGender()
        {
            return gender;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime + ((name == null) ? 0 : name.GetHashCode());
            hash *= prime + ((email == null) ? 0 : email.GetHashCode());
            hash *= prime + ((gender == null) ? 0 : gender.GetHashCode());

            if (hash < 0) hash = -hash;

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

            Author that = (Author)obj;
            return Equals(this.name, that.name) && 
               Equals(this.email, that) && 
                Equals(this.gender, that.gender);
        }

        public override string ToString()
        {
            return "Author[name = " + name + ", email = " + email + "gender = " + gender + "]";
        }
    }
}
