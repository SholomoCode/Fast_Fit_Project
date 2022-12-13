using Fast_Fit_Final_Project.Models;
using Fast_Fit_Final_Project.ViewModels;
using FastFit_Final_Project.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Fast_Fit_Final_Project.Controllers
{
    public class MaleShoeController : Controller
    {

        internal static Dictionary<string, string> CountryChoices = new Dictionary<string, string>()
        {
            {"us", "Us"},
            {"uk", "Uk"},
            {"eu", "Eu"},
            {"australia", "Australia"},
            {"china", "China"},
            {"japan", "Japan"}
        };

        public IActionResult Index()
        {
            ViewBag.country = CountryChoices;
            return View();
        }

        public IActionResult Size(string country, string size)
        {
            List<Country> countries = MaleShoeSizeData.FindAll();
            ViewBag.title = "All Male Sizes";
            ViewBag.countries = countries;
            return View();
        }
    }
}
