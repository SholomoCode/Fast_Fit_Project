using System;

namespace Fast_Fit_Final_Project.Model
{
    public class MaleShoe
    {
        public int Id { get; }
        static private int nextId = 1;

        public string Value { get; set; }

        public MaleShoe()
        {
            Id = nextId;
            nextId++;
        }

        public MaleShoe(string value) : this()
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return obj is MaleShoe male &&
                Id == male.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
