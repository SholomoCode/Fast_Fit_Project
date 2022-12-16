using FastFitProject.Models;
using System;

namespace FastFitProject.Models
{
    public abstract class Shoe
    {
        public int Id { get; }
        static private int nextId = 1;
        public string Value { get; set; }

        public Shoe()
        {
            Id = nextId;
            nextId++;
        }

        public Shoe(string value) : this()
        {
            Value = value;

        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return obj is Shoe female &&
                    Id == female.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
