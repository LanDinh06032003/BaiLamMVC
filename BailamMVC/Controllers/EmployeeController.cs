namespace BailamMVC.Controllers
{
    using BailamMVC.Models;
    using BailamMVC.Data;
    using BailamMVC.Models.Entities;
    using BailamMVC.Models.Process;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

        public IActionResult Create()
        {
            var employee = _context.Employee.OrderByDescending(p => p.EmployeeId).FirstOrDefault();
            var EmployeeId = employee == null ? "PS0" : employee.EmployeeId;
            var autoGenerateId = new AutoGenerateId();
            var newEmployeeId = autoGenerateId.GenerateId(EmployeeId);
            var newEmployee = new Employee
            {
                EmployeeId = newEmployeeId
            };
            return View(newEmployee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Age")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public async Task<IActionResult> Edit(string id) {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
    }
}


    