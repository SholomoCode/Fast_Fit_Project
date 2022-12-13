using Fast_Fit_Final_Project.Data;
using Fast_Fit_Final_Project.Model;
using Fast_Fit_Final_Project.ViewModels;
using FastFit_Final_Project.Data;
using FastFitProject.Data;
using FastFitProject.Models;
using FastFitProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
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



      


        public IActionResult Index()
        {
            return View();
        }

  


       
    }
}
