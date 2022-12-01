using Fast_Fit_Final_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Fast_Fit_Final_Project.ViewModels
{
    public class MaleShoeViewModel
    {

        public Country Location { get; set; }

       /* public List<SelectListItem> Country1 { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(Country.Japan.ToString(), ((int) Country.Japan).ToString()),
            new SelectListItem(Country.Eu.ToString(), ((int) Country.Eu).ToString()),
            new SelectListItem(Country.Uk.ToString(), ((int) Country.Uk).ToString()),
            new SelectListItem(Country.Australian.ToString(), ((int) Country.Australian).ToString()),
            new SelectListItem(Country.Asian.ToString(), ((int) Country.Asian).ToString()),
            new SelectListItem(Country.UsFemale.ToString(), ((int) Country.UsFemale).ToString())
        };*/
    }
}
