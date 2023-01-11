using FastFitProject.Models;
using System;
using System.Xml.Linq;

namespace FastFitProject.Models
{
    public class Country
    {
        public int Id { get; set; }
        static private int nextId = 1;
 
        public Japan Japan { get; set; }
        public Eu Eu { get; set; }
        public Uk Uk { get; set; }
        public Australia Australia { get; set; }
        public China China { get; set; }
        public Us Us { get; set; } 
        
        public USMaleFemaleDif USMaleFemaleDif { get; set; }

        

        public Country() 
        { 
        Id = nextId;
            nextId++;
        }

        public Country(Japan japan, Eu eu, Uk uk, Australia australia, China china, Us us, USMaleFemaleDif usMaleFemaleDif) : this()
        {
            Japan = japan;
            Eu = eu;
            Uk = uk;
            Australia = australia;
            China = china;
            Us = us;
            USMaleFemaleDif = usMaleFemaleDif;
        }
        
           
        


        public override string ToString()
        {
            string output = "";
            if (Japan.Equals(""))
            {
                Japan.Value = "Data not available";
            }
            if (Eu.Value.Equals("") || Eu.Value == null)
            {
                Eu.Value = "Data not available";
            }
            if (Uk.Value.Equals("") || Uk.Value == null)
            {
                Uk.Value = "Data not available";
            }
            if (Australia.Value.Equals("") || Australia.Value == null)
            {
                Australia.Value = "Data not available";
            }
            if (China.Value.Equals("") || China.Value == null)
            {
                China.Value = "Data not available";
            }

            if (Us.Value.Equals("") || Us.Value == null)
            {
                Us.Value = "Data not available";
            }

            output = string.Format("\nID: %d\n" +
                    "Japan: %s\n" +
                    "Eu: %s\n" +
                    "Uk: %s\n" +
                    "Australia: %s\n" +
                    "Us: %s\n" +
                    "China: %s\n", Id, Japan, Eu, Uk, Australia, China, Us);
            return output;
        }

        public override bool Equals(object obj)
        {
            return obj is Country country &&
                Id == country.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
