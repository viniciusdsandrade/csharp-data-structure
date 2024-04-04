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
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty");

            if (price < 0)
                throw new ArgumentException("Price cannot be negative");

            this.name = name;
            this.author = author;
            this.price = price;
        }

        public Book(string name, Author author, double price, int quantiyty)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty");

            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative");

            if (price < 0)
                throw new ArgumentException("Price cannot be negative");

            this.name = name;
            this.author = author;
            this.price = price;
            this.quantity = quantiyty;
        }

        public string GetName() => name;

        public Author GetAuthor() => author;

        public double GetPrice() => price;

        public void SetPrice(double price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }

            this.price = price;
        }

        public int GetQuantity() => quantity;

        public void SetQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative");
            }
            this.quantity = quantity;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime + name.GetHashCode();
            hash *= prime + author.GetHashCode();
            hash *= prime + price.GetHashCode();
            hash *= prime + quantity.GetHashCode();

            if (hash < 0) _ = -hash;

            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            Book that = (Book)obj;

            return Equals(this.name, that.name) &&
                Equals(this.author, that.author) &&
                Equals(this.price, that.price) &&
                Equals(this.quantity, that.quantity);
        }

        public override string ToString() => "Book[name = " + name + ", " + author + ", price = " + price + ", quantity = " + quantity + "]";
    }
    public class Author
    {
        private readonly string name;
        private string email;
        private readonly char gender;

        public Author(string name, string email, char gender)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty");

            if (!IsValidEmail(email))
                throw new ArgumentException("Invalid email format");

            if (!IsValidGender(gender))
                throw new ArgumentException("Invalid gender");

            this.name = name;
            this.email = email;
            this.gender = gender;
        }

        private static bool IsValidGender(char gender)
        {
            return gender == 'M' || gender == 'F' || gender == 'm' || gender == 'f';
        }

        public string GetName() => name;

        public string GetEmail() => email;

        public void SetEmail(string email)
        {
            if (!IsValidEmail(email))
                throw new ArgumentException("Invalid email format");

            this.email = email;
        }

        private static bool IsValidEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && email.Contains("@");
        }

        public char GetGender() => gender;

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime + name.GetHashCode();
            hash *= prime + email.GetHashCode();
            hash *= prime + gender.GetHashCode();

            if (hash < 0) hash = -hash;

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

            Author that = (Author)obj;

            return Equals(this.name, that.name) &&
               Equals(this.email, that) &&
                Equals(this.gender, that.gender);
        }

        public override string ToString() => "Author[name = " + name + ", email = " + email + ", gender = " + gender + "]";
    }
}
