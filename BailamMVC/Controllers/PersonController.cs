namespace BailamMVC.Controllers
{
    using BailamMVC.Data;
    using BailamMVC.Models;
    using BailamMVC.Models.Entities;
    using BailamMVC.Models.Process; 
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.EntityFrameworkCore;
    using OfficeOpenXml;
    using System.Threading.Tasks;

    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();
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
        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
        if (file != null)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
            {
                ModelState.AddModelError("", "Please choose excel file to upload!");
            }
            else
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Excels");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + fileExtension;
                var filePath = Path.Combine(folderPath, fileName);
                var fileLocation = new FileInfo(filePath).ToString();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var dt = _excelProcess.ExcelToDataTable(fileLocation);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var ps = new Person
                    {
                        PersonId = dt.Rows[i][0].ToString(),
                        FullName = dt.Rows[i][1].ToString(),
                        AddRess = dt.Rows[i][2].ToString()
                    };
                    _context.Add(ps);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        return View();
        }
        public IActionResult Download()
        {
            var fileName = "YourName" + ".xlsx";
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                worksheet.Cells["A1"].Value = "PersonId";
                worksheet.Cells["B1"].Value = "FullName";
                worksheet.Cells["C1"].Value = "AddRess";
                var personList = _context.Person.ToList();
                worksheet.Cells["A2"].LoadFromCollection(personList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
    }
}