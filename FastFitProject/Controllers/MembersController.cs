using Fast_Fit_Final_Project.Data;
using Fast_Fit_Final_Project.Model;
using Fast_Fit_Final_Project.ViewModels;
using FastFitProject.Data;
using FastFitProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
//js not javascript
using System.Linq;
using System.Reflection;

namespace Fast_Fit_Final_Project.Controllers
{
    public class MembersController : Controller
    {
        /*private FastFitDbContext context;

        public MembersController(FastFitDbContext dbContext)
        {
            context = dbContext;
        }*/


        //js  not javascript
        private ApplicationDbContext context;


        public IActionResult Index()
        {
            List<Members> Member = new List<Members>(MemberData.GetAll());
            return View();
        }

        public IActionResult Add()
        {
            //js not javaScript
            List<Search> searches = context.Searches.ToList();

            MembersViewModel addMembersViewModel = new MembersViewModel();

            return View(addMembersViewModel);
        }

        [HttpPost]
        public IActionResult Add(MembersViewModel addMembersViewModel)
        {
            if (ModelState.IsValid)
            {
                Members newMember = new Members 
                { 
                    Name = addMembersViewModel.Name,
                    Age = addMembersViewModel.Age,
                    ShoeSize = addMembersViewModel.ShoeSize,
                    Gender = addMembersViewModel.Gender,
                };

                MemberData.Add(newMember);

                return Redirect("/Members");
            }
            return View(addMembersViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.members = MemberData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] memberIds)
        {
            foreach (int memberId in memberIds)
            {
                MemberData.Remove(memberId);
            }

            return Redirect("/Members");
        }
    }
}
