using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings;
namespace BailamMVC.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }

}