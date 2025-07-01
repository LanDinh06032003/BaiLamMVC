using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings;
namespace BailamMVC.Controllers
{
    public class HelloWorld : Controller
    {
        public IActionResult Index(){
            return View();
        }

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}