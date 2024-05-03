using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
    public class Student : Person
    {
        private int nCouses;
        private string[] courses;
        private int[] grades;

        public Student(string name, string address) : base(name, address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address cannot be null or empty");

            this.name = name;
            this.address = address;
            this.nCouses = 0;
            this.courses = new string[30];
            this.grades = new int[30];
            this.grades[0] = 0;
        }

        public void AddCourseGrade(string course, int grade)
        {
            if (string.IsNullOrWhiteSpace(course))
                throw new ArgumentException("Course name cannot be null or empty");

            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100");

            this.nCouses++;
        }

        private void PrintGrades()
        {
            for (int i = 0; i < this.nCouses; i++)
                Console.WriteLine($"{this.courses[i]}: {this.grades[i]}");
        }

        public double GetAverageGrade()
        {
            double sum = 0;
            for (var i = 0; i < this.nCouses; i++)
                sum += this.grades[i];

            return sum / this.nCouses;
        }

        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var that = (Student)obj;

            return Equals(this.name, that.name) &&
                   Equals(this.address, that.address);
        }

        public override int GetHashCode()
        {
            const int prime = 13;
            var hash = 1;

            hash *= prime + name.GetHashCode();
            hash *= prime + address.GetHashCode();

            if (hash < 0) hash = -hash;

            return hash;
        }

        public override string ToString() => $"Student[{base.ToString()}]";
    }
}