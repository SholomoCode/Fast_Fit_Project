namespace Fast_Fit_Final_Project.Models
{
    public class Country
    {
        public int Id { get; set; }
        static private int nextId = 1;


        public string Japan { get; set; }
        public string Eu { get; set; }
        public string Uk { get; set; }
        public string Australia { get; set; }
        public string Asia { get; set; }
        public string  UsFemale { get; set; }
        public string UsMale { get; set; }
    }
}
