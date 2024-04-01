using System.Diagnostics;
using System.Xml.Linq;
using static System.Console;
using static System.Math;

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
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("first name cannot be null or empty");

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException("last name cannot be null or empty");

            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Employee(int id, string firstName, string lastName, double salary)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("first name cannot be null or empty");

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException("last name cannot be null or empty");

            if (salary < 0)
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
            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }

            this.salary = salary;
        }

        public double GetAnnualSalary() => salary * 13;
 
        public double RaiseSalary(double percent) => salary += salary * percent / 100;

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime  + ((firstName == null) ? 0 : firstName.GetHashCode());
            hash *= prime  + id;
            hash *= prime + ((lastName == null) ? 0 : lastName.GetHashCode());

            if (hash < 0) _ = -hash;

            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            Employee other = (Employee)obj;
            
            return Equals(id, other.id) && 
                Equals(firstName, other.firstName) && 
                Equals(lastName, other.lastName) && 
                Equals(salary, other.salary);
        }

        public override string ToString() => "Employee[id = " + id + ", name = " + GetName() + ", salary = " + salary + "]";
    }
}