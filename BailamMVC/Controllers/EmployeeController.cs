using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings;
namespace BailamMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index(){
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}