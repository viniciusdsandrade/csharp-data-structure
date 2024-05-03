using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
    public class SalaryTeacher : Teacher
    {
        private double weeklySalary;

        public SalaryTeacher(string name, string address, double weeklySalary) : base(name, address)
        {
            this.name = name;
            this.address = address;
            this.weeklySalary = weeklySalary;
        }

        public double GetWeeklySalary() => weeklySalary;

        public void SetWeeklySalary(double weeklySalary)
        {
            if (weeklySalary < 0)
                throw new ArgumentException("Weekly salary must be greater than or equal to 0");

            this.weeklySalary = weeklySalary;
        }

        public override double CalculateSalary() => weeklySalary * 4;


        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var that = (SalaryTeacher)obj;

            return Equals(this.name, that.name) &&
                   Equals(this.address, that.address) &&
                   Equals(this.weeklySalary, that.weeklySalary);
        }

        public override int GetHashCode()
        {
            const int prime = 13;
            var hash = 1;

            hash *= prime + name.GetHashCode();
            hash *= prime + address.GetHashCode();
            hash *= prime + weeklySalary.GetHashCode();

            if (hash < 0) hash = -hash;

            return hash;
        }

        public override string ToString() =>
            $"SalaryTeacher[name={name}, email={address}, weeklySalary={weeklySalary}]";
    }
}