using Fast_Fit_Final_Project.Data;
using Fast_Fit_Final_Project.Model;
using Fast_Fit_Final_Project.ViewModels;
using FastFitProject.Data;
using FastFitProject.Models;
using FastFitProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

            List<Search> search = context.Searches
            .Include(s => s.members)
            .ToList();

            return View(search);

        }



        [HttpGet]
        public IActionResult Add()
        {
            List<Members> members = context.Members.ToList();
            AddSearchViewModel addSearchViewModel = new AddSearchViewModel(members);

            return View(addSearchViewModel);
        }




        [HttpPost]
        public IActionResult ProcessCreateMembersForm(AddSearchViewModel addSearchViewModel)
        {


            if (ModelState.IsValid)
            {
                Members theMember = context.Members.Find(addSearchViewModel.MembersId);
                Search newSearch = new Search
                {
                    members = theMember
                }; 

                context.Searches.Add(newSearch);
                context.SaveChanges();
                return Redirect("/Search");
            }
            return View(addSearchViewModel);

        }
    }
}
