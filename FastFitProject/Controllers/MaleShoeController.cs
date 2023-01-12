using FastFitProject.Models;
using FastFitProject.ViewModels;
using FastFitProject.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FastFitProject.Controllers
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
            ViewBag.title = "All Man Sizes";
            ViewBag.countries = countries;
            return View();
        }
    }
}
