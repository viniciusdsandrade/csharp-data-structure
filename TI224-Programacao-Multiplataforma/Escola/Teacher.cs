using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
    public abstract class Teacher : Person
    {
        private int nCourses;
        private string[] courses;

        protected Teacher(string name, string address) : base(name, address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address cannot be null or empty");

            this.name = name;
            this.address = address;
            this.nCourses = 0;
            this.courses = new string[30];
        }

        public bool AddCourse(string course)
        {
            if (this.nCourses >= 30)
                return false;

            if (this.courses.Contains(course))
                return false;

            this.courses[this.nCourses] = course;
            this.nCourses++;
            return true;
        }

        public bool RemoveCourse(string course)
        {
            if (!this.courses.Contains(course))
                return false;

            var index = Array.IndexOf(this.courses, course);

            for (var i = index; i < this.nCourses - 1; i++)
                this.courses[i] = this.courses[i + 1];


            this.nCourses--;
            return true;
        }

        public abstract double CalculateSalary();

        public override string ToString()
        {
            //Precisamos verificar a quantidade de cursos para não imprimir lixo
            var courses = new StringBuilder();
            for (var i = 0; i < this.nCourses; i++)
                courses.Append(this.courses[i] + ", ");
            
            return $"Teacher[name={name}, email={address}, courses=[{courses}]]";
        }
    }
}