using Fast_Fit_Final_Project.Models;
using System;

namespace Fast_Fit_Final_Project.Model
{
    public abstract class FemaleShoe
    {
        public int Id { get; }
        static private int nextId = 1;
        public string Value { get; set; }

        public FemaleShoe()
        {
            Id = nextId;
            nextId++;
        }

        public FemaleShoe(string value) : this()
        {
            Value = value;

        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return obj is FemaleShoe female &&
                    Id == female.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
