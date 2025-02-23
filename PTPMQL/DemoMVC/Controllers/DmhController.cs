using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class DmhController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Dmh dmh)
        {
            double finalScore = dmh.Dtb();
            ViewBag.ScoreResult = $"{finalScore}";
            return View();
        }
    }
}