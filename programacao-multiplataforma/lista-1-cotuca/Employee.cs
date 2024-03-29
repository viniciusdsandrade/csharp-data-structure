using System.Diagnostics;
using static System.Console;
using static System.Math;

namespace Employee
{
    public class Employee
    {
        private readonly int id;
        private readonly string firstName;
        private readonly string lastName;
        private double salary = 0.0;

        public Employee(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Employee(int id, string firstName, string lastName, double salary)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
        }

        public int GetId()
        {
            return id;
        }
        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public double GetSalary()
        {
            return salary;
        }

        public string GetName()
        {
            return firstName + " " + lastName;
        }

        public void SetSalary(double salary)
        {
            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }

            this.salary = salary;
        }

        public double GetAnnualSalary()
        {
            return salary * 13;
        }

        public double RaiseSalary(double percent)
        {
            salary += salary * percent / 100;
            return salary;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime  + ((firstName == null) ? 0 : firstName.GetHashCode());
            hash *= prime  + id;
            hash *= prime + ((lastName == null) ? 0 : lastName.GetHashCode());
    
            if(hash < 0) { hash = -hash; }

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

            Employee other = (Employee)obj;
            
            return Equals(id, other.id) && 
                Equals(firstName, other.firstName) && 
                Equals(lastName, other.lastName) && 
                Equals(salary, other.salary);
        }

        public override string ToString()
        {
            return "Employee[id=" + id + ",name=" + GetName() + ",salary=" + salary + "]";
        }
    }
}