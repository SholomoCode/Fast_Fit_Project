using Fast_Fit_Final_Project.ViewModels;
using FastFitProject.Data;
using FastFitProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Fit_Final_Project.Controllers
{
    public class SearchController : Controller
    {

        private ApplicationDbContext context;


     
        public SearchController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
   public IActionResult Index()
        {
            List<Search> searches = context.Searches.ToList();
            return View(searches);
        }


        [HttpPost]
        public IActionResult ProcessCreateEventCategoryForm(MembersViewModel membersViewModel)
        {
            if (ModelState.IsValid)
            {
                Search newMember = new Search
                {
                    Name = membersViewModel.Name
                };

                context.Searches.Add(newMember);
                context.SaveChanges();

                return Redirect("/Search");
            }

            return View("Index", membersViewModel);
        }



    }
}
