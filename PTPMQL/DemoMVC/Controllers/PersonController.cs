using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using DemoMVC.Models;
namespace DemoMVC.Controllers
{
    public class PersonController : Controller
    {
    public IActionResult Index()
        {
            return View();
        }
    [HttpPost]
    public IActionResult Index(Person ps)
    {
        string strOutput = "Xin chao " + ps.PersonId + "-" + ps.FullName + "-" + ps.Address;
        ViewBag.infoPerson = strOutput;
        return View();
    }
    public IActionResult Creat()
        {
            return View();
        }
    }
}