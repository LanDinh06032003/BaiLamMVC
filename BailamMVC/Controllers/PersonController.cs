namespace BailamMVC.Controllers
{
    using BailamMVC.Data;
    using BailamMVC.Models;
    using BailamMVC.Models.Entities;
    using BailamMVC.Models.Process;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            return View(await _context.Person.ToListAsync());
        }

        //create a new person
        public IActionResult Create()
        {
            var person = _context.Person.OrderByDescending(p => p.PersonId).FirstOrDefault();
            var PersonId = person == null ? "PS0" : person.PersonId;
            var autoGenerateId = new AutoGenerateId();
            var newPersonId = autoGenerateId.GenerateId(PersonId);
            var newPerson = new Person
            {
                PersonId = newPersonId
            };
            return View(newPerson);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FullName,AddRess,Height")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
    }
}