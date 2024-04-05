namespace Company
{
    public class Employee
    {
        private readonly int id;
        private readonly string firstName;
        private readonly string lastName;
        private double salary = 0.0;

        public Employee(int id, string firstName, string lastName)
        {
            if (Int128.IsNegative(id))
                throw new ArgumentException("ID must be a positive integer.", nameof(id));
            
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be null or empty.", nameof(firstName));       

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName)); 

            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Employee(int id, string firstName, string lastName, double salary)
        {
            if (Int128.IsNegative(id))
                throw new ArgumentException("ID must be a positive integer.", nameof(id));

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be null or empty.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));

            if (double.IsNegative(salary))
                throw new ArgumentException("Salary cannot be negative");

            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
        }

        public int GetId() => id;

        public string GetFirstName() => firstName;

        public string GetLastName() => lastName;

        public double GetSalary() => salary;

        public string GetName() => firstName + " " + lastName;

        public void SetSalary(double salary)
        {
            if (double.IsNegative(salary))  
                throw new ArgumentException("Salary cannot be negative");

            this.salary = salary;
        }

        public double GetAnnualSalary() => salary * 13;

        public double RaiseSalary(double percent) => salary += salary * percent / 100;

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime + ((firstName == null) ? 0 : firstName.GetHashCode());
            hash *= prime + id;
            hash *= prime + ((lastName == null) ? 0 : lastName.GetHashCode());

            if (hash < 0) hash = -hash;

            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            Employee other = (Employee)obj;

            return Equals(this.id, other.id) &&
                Equals(this.firstName, other.firstName) &&
                Equals(this.lastName, other.lastName) &&
                Equals(this.salary, other.salary);
        }

        public override string ToString() => "Employee[id = " + id + ", name = " + GetName() + ", salary = " + salary + "]";
    }
}