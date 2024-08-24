using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Data;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDBContext _appDbContext;

        public EmployeeController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> ListEmployees()
        {
            List<Employee> listEmployees = await _appDbContext.Employees.ToListAsync();
            return View(listEmployees);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(ListEmployees));
        }

        public async Task<IActionResult> UpdateEmployee(int Id)
        {
            Employee employee = await _appDbContext.Employees.FirstAsync(e => e.Id == Id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            _appDbContext.Employees.Update(employee);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(ListEmployees));
        }

        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            Employee employee = await _appDbContext.Employees.FirstAsync(e => e.Id == Id);

            _appDbContext.Employees.Remove(employee);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(ListEmployees));
        }
    }
}