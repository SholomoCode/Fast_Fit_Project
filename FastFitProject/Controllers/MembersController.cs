using Fast_Fit_Final_Project.Data;
using Fast_Fit_Final_Project.Model;
using Fast_Fit_Final_Project.Models;
using Fast_Fit_Final_Project.ViewModels;
using FastFit_Final_Project.Data;
using FastFitProject.Data;
using FastFitProject.Models;
using FastFitProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
//js not javascript
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Fast_Fit_Final_Project.Controllers
{
    public class MembersController : Controller
    {
        private ApplicationDbContext context;

        public MembersController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Members> Members = context.Members.ToList();
            return View(Members);
        }

        public IActionResult Add()
        {
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

                context.Members.Add(newMember);
                context.SaveChanges();

                return Redirect("/Members");
            }
            return View(addMembersViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.members = context.Members.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] memberIds)
        {
            foreach (int memberId in memberIds)
            {
                Members theMember = context.Members.Find(memberId);
                context.Members.Remove(theMember);
            }
            context.SaveChanges();

            return Redirect("/Members");
        }

        [HttpGet]
        [Route("Members/Edit/{memberId}")]
        public IActionResult Edit(int id)
        {
            Members theMember = context.Members.Find(id+1);
            MemberDetailViewModel viewModel = new MemberDetailViewModel(theMember);

            return View(viewModel);
        }

        [HttpPost]
        [Route("Members/Edit")]
        public IActionResult SubmitEditMemberForm(MemberDetailViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Members editingMembers = context.Members.Find(viewModel.Id);
                editingMembers.Name = viewModel.Name;
                editingMembers.Age = viewModel.Age;
                editingMembers.ShoeSize = viewModel.ShoeSize;
                editingMembers.Gender = viewModel.Gender;

                context.SaveChanges();


                return Redirect("/Members");
            }

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Result(Members members, string countryName)
        {
            List<Country> members1;
            countryName = "Uk";
            //value = members.ShoeSize;

            if (members.Gender == 0) //0 = Male
            {
                members1 = MaleShoeSizeData.Find(members.ShoeSize, countryName);
                ViewBag.newShoeSize = members1;
            }
            else
            {
                members1 = FemaleShoeSizeData.FindByValue(members.ShoeSize);
                ViewBag.newShoeSize = members1;
            }

            return View();
        }

        
    }
}
