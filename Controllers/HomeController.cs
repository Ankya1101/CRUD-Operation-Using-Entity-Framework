using CRUD_DEMO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUD_DEMO.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpDBContext empDBContext;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(EmpDBContext empDBContext)
        {
            this.empDBContext = empDBContext;
        }

        public async Task<IActionResult> Index()
        {
            var empData = await empDBContext.Employees.ToListAsync();
            return View(empData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            if(ModelState.IsValid)
            {
                await empDBContext.Employees.AddAsync(emp);
                await empDBContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(emp);
        }

        public async Task<IActionResult> Details(int id)
        {
            var empData = await empDBContext.Employees.FirstOrDefaultAsync(x=>x.Id==id);
            return View(empData);
        }

        [HttpPost]
        public async Task<IActionResult> Details(int? id)
        {
            if(id==null || empDBContext.Employees ==null )
            {
                return NotFound();
            }
            var empData = await empDBContext.Employees.FirstOrDefaultAsync(x=> x.Id ==id);   
            if(empData==null)
            {
                return NotFound();
            }
            return View(empData);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || empDBContext.Employees == null)
            {
                return NotFound();
            }
            var empData = await empDBContext.Employees.FindAsync(id);
            if (empData == null)
            {
                return NotFound();
            }
            return View(empData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id , Employee emp)
        {
            if(id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                empDBContext.Employees.Update(emp);
                await empDBContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(emp);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || empDBContext.Employees == null)
            {
                return NotFound();
            }
            var empData = await empDBContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (empData == null)
            {
                return NotFound();
            }
            return View(empData);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteData(int? id)
        {
            var empdata = await empDBContext.Employees.FindAsync(id);
            if(empdata != null)
            {
                empDBContext.Employees.Remove(empdata);
            }
            await empDBContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
