using Fast_Fit_Final_Project.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace FastFitProject.Models
{
    public class Search
    {


        public string Name { get; set; }

        public int Id { get; set; }

        public List<Members> members { get; set; }

        public Search(string name)
        {
            Name = name;
        }


        public Search()
        {

        }
    }
}
