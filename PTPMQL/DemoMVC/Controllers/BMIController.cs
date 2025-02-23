using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using DemoMVC.Models;
namespace DemoMVC.Controllers
{
    public class BMIController : Controller
    {
    public IActionResult Index()
        {
            return View();
        }
    [HttpPost]
        public IActionResult Index(BMI bm)
        {
            double bmi = bm.CalculateBMI();
            string category = bm.GetBMICategory();
            ViewBag.BMIResult = $"{bmi:f2} {category}";
            return View();
        }
    }
}