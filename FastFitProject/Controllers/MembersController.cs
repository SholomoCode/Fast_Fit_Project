
using FastFitProject.Models;
using FastFitProject.ViewModels;
using FastFitProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

namespace FastFitProject.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private ApplicationDbContext context;

        public MembersController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        [AllowAnonymous]
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
        public IActionResult Edit(int id)
        {
            Members theMember = context.Members.Find(id);
            MemberDetailViewModel viewModel = new MemberDetailViewModel(theMember);

            return View(viewModel);
        }

        [HttpPost]
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

        public IActionResult MyControllerAction()
        {
            return View();
        }


        public IActionResult Result(int id, string countryName = "us")
        {
            List<Country> members1;
            Members theMember = context.Members.Find(id);
           MembersViewModel viewModel = new MembersViewModel(theMember);
            string size = viewModel.ShoeSize;


                if (theMember.Gender.ToString() == "Male") //0 = Male
                {
                    if (!string.IsNullOrEmpty(size))
                    {
                        members1 = MaleShoeSizeData.FindByCountryAndSize(countryName, size);
                        ViewBag.newShoeSize = members1;
                    }
                    else if (size == null || countryName == null)
                    {
                        members1 = MaleShoeSizeData.FindAll();
                        ViewBag.newShoeSize = members1;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(size))
                    {
                        members1 = FemaleShoeSizeData.FindByCountryAndSize(countryName, size);
                        ViewBag.newShoeSize = members1;
                    }
                    else if (size == null || countryName == null)
                    {
                        members1 = FemaleShoeSizeData.FindAll();
                        ViewBag.newShoeSize = members1;
                    }
                }
            
             
            ViewBag.country = MaleShoeController.CountryChoices;
            return View(viewModel);
        }

        
    }
}
