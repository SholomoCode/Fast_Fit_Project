using Fast_Fit_Final_Project.Controllers;
using Fast_Fit_Final_Project.Models;
using System;

namespace Fast_Fit_Final_Project.Model
{
    public class Members
    {
        public int Id { get; set; }
        static private int nextId = 1;
        public string Name { get; set; }
        public int Age { get; set; }

        public double ShoeSize { get; set; }
        public MemberGender Gender { get; set; }


        //justus
        public SearchController Search { get; set; }
        //justus
        public int SearchId { get; set; }

        public Members()
        {
            Id = nextId;
            nextId++;
        }

        public Members( string name, int age, double shoeSize) : this()
        {
            Name = name;
            Age = age;
            ShoeSize = shoeSize;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Members members &&
                   Id == members.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
