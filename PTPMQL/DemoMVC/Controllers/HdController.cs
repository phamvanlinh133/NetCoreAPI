using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using DemoMVC.Models;
namespace DemoMVC.Controllers
{
    public class HdController : Controller
    {
    public IActionResult Index()
        {
            return View();
        }
    [HttpPost]
        public IActionResult Index(HoaDon hd)
        {
            double thanhtien = hd.ThanhTien();
            ViewBag.HDResult = $"{thanhtien:f3}";
            return View();
        }
    }
}