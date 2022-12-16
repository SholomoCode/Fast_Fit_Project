using FastFitProject.Models;
using FastFitProject.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FastFitProject.Controllers
{
    public class FemaleShoeController : Controller
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
            List<Country> countries = FemaleShoeSizeData.FindAll();
            ViewBag.title = "All Female Sizes";
            ViewBag.countries = countries;
            return View();
        }



    }
}
