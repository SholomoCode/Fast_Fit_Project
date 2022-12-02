using Fast_Fit_Final_Project.Model;
using Fast_Fit_Final_Project.Models;
using System.Collections.Generic;

namespace FastFit_Final_Project.Data
{
    public class MaleShoeSizeData
    {
        static private string DATA_FILE = "Data/MaleShoeData.csv";

        static bool IsDataLoaded;

        static List<Country> countries;

        static private List<MaleShoe> Value = new List<MaleShoe>();
    }
}
