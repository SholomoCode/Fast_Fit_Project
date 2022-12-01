using Microsoft.AspNetCore.Mvc;

namespace Fast_Fit_Final_Project.Controllers
{
    public class FemaleShoeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Add()
        {
            FemaleShoeController femaleShoeController = new FemaleShoeController();
            return View(femaleShoeController);
        }

        
        
    }
}
