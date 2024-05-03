using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
    public class HourlyTeacher : Teacher
    {
        private double hourlySalary;
        private int hoursWorked;

        public HourlyTeacher(string name, string address, double hourlySalary) : base(name, address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address cannot be null or empty");

            if (hourlySalary < 0)
                throw new ArgumentException("Hourly salary must be greater than 0");

            this.name = name;
            this.address = address;
            this.hourlySalary = hourlySalary;
        }

        public HourlyTeacher(string name, string address, double hourlySalary, int hoursWorked) : this(name, address,
            hourlySalary)
        {
            this.hoursWorked = hoursWorked;
        }

        public double GetHourlySalary() => hourlySalary;
        public int GetHoursWorked() => hoursWorked;

        public void SetHoursWorked(int hoursWorked)
        {
            if (hoursWorked < 0)
                throw new ArgumentException("Hours worked must be greater than or equal to 0");

            this.hoursWorked = hoursWorked;
        }

        public double CalculateWeeklyPay() => GetSalary() / 4;

        public double GetSalary() => hourlySalary * hoursWorked;

        public override double CalculateSalary() => GetSalary();

        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var that = (HourlyTeacher)obj;

            return base.Equals(that) &&
                   Equals(this.hourlySalary, that.hourlySalary) &&
                   Equals(this.hoursWorked, that.hoursWorked);
        }

        public override int GetHashCode()
        {
            const int prime = 13;
            var hash = base.GetHashCode();

            hash *= prime + hourlySalary.GetHashCode();
            hash *= prime + hoursWorked.GetHashCode();

            if (hash < 0) hash = -hash;

            return hash;
        }

        public override string ToString() =>
            $"HourlyTeacher[{base.ToString()}, hourlySalary={hourlySalary}, hoursWorked={hoursWorked}]";
    }
}