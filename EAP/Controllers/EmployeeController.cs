using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EAP.Models;

namespace EAP.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EAPContext _context;

        public EmployeeController(EAPContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeClass.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeClass = await _context.EmployeeClass
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (employeeClass == null)
            {
                return NotFound();
            }

            return View(employeeClass);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,Lastname,Firstname,Phonenumber,Email")] EmployeeClass employeeClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeClass);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeClass = await _context.EmployeeClass.FindAsync(id);
            if (employeeClass == null)
            {
                return NotFound();
            }
            return View(employeeClass);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,Lastname,Firstname,Phonenumber,Email")] EmployeeClass employeeClass)
        {
            if (id != employeeClass.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeClassExists(employeeClass.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeClass);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeClass = await _context.EmployeeClass
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (employeeClass == null)
            {
                return NotFound();
            }

            return View(employeeClass);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeClass = await _context.EmployeeClass.FindAsync(id);
            _context.EmployeeClass.Remove(employeeClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeClassExists(int id)
        {
            return _context.EmployeeClass.Any(e => e.StudentID == id);
        }
    }
}
