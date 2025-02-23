using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class EmployeeController : Controller
    {
    public IActionResult Index()
        {
            return View();
        }
    public IActionResult Update()
        {
            return View();
        }
    }
}