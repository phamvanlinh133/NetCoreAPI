using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace DemoMVC.Controllers
{
    public class HelloWorldController : Controller
    {   
        // GET: /HelloWorld/
        // public string Index()
        // {
        //     return "This is my default action...";
        // } 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Index()
        {
            return View();
        }
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
