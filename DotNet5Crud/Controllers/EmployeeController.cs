using DotNet5Crud.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace DotNet5Crud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;  // _context variable of databaseContext type which is assignable but not mutable
        public EmployeeController(EmployeeDbContext context) //creation of constructor passing data from form to database
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string SearchText) //async action method of showing index of employees
        {
            List<Employee> employees;
            
            if (SearchText !="" && SearchText !=null)
            {
                 employees =await _context.Employees.Where(e => e.EmployeeName.Contains(SearchText)).ToListAsync();
            }
            else

             employees = await _context.Employees.ToListAsync();
             return View(employees);
        }



        [HttpGet]
        public IActionResult Create() // httpget 
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee,List<IFormFile> Image)
        {
            
            
           // if (ModelState.IsValid)
           // {
                foreach (var i in Image)
                {
                    if (i.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await i.CopyToAsync(stream);
                            employee.Image = stream.ToArray();
                        }
                    }
                }

                // string uniqueFileName = UploadedFile(employee);
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

           // }
            return View(employee);
        }

   

        public async Task<IActionResult> Edit(int? employeeId)
        {
            if (employeeId == null || employeeId <= 0)
                return BadRequest();
            var employeeInDb = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (employeeInDb == null)
                return NotFound();
            return View(employeeInDb);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Delete(int? employeeId)
        {
            if (employeeId == null || employeeId <= 0)
                return BadRequest();
            var employeeInDb = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (employeeInDb == null)
                return NotFound();
            _context.Employees.Remove(employeeInDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 



        public async Task<IActionResult> Details(int? employeeId)
        {
            

            
            if (employeeId == null || employeeId <= 0)
                return BadRequest();
            var employeeInDb = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (employeeInDb == null)
                return NotFound();
            return View(employeeInDb);
           // try
           // {

           // }
           //catch()
        }

        
    }

}
