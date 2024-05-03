using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
    public class Person
    {
        public string name;
        public string address;

        public Person(string name, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address cannot be null or empty");

            this.name = name;
            this.address = address;
        }

        public string GetName() => name;
        public string GetAddress() => address;

        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var that = (Person)obj;

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

        public override string ToString() => $"Person[name={name}, email={address}]";
    }
}