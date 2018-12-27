using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EAP.Models;

namespace EAP.Controllers
{
    using Microsoft.AspNetCore.Cors;

    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class EmployeeClassesController : ControllerBase
    {
        private readonly EAPContext _context;

        public EmployeeClassesController(EAPContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeClasses
        [HttpGet]
        public IEnumerable<EmployeeClass> GetEmployeeClass()
        {
            return _context.EmployeeClass;
        }

        // GET: api/EmployeeClasses/5
        [HttpGet("{id}")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> GetEmployeeClass([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeClass = await _context.EmployeeClass.FindAsync(id);

            if (employeeClass == null)
            {
                return NotFound();
            }

            return Ok(employeeClass);
        }

        // PUT: api/EmployeeClasses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeClass([FromRoute] int id, [FromBody] EmployeeClass employeeClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeClass.StudentID)
            {
                return BadRequest();
            }

            _context.Entry(employeeClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeClasses
        [HttpPost]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> PostEmployeeClass([FromBody] EmployeeClass employeeClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmployeeClass.Add(employeeClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeClass", new { id = employeeClass.StudentID }, employeeClass);
        }

        // DELETE: api/EmployeeClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeClass([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeClass = await _context.EmployeeClass.FindAsync(id);
            if (employeeClass == null)
            {
                return NotFound();
            }

            _context.EmployeeClass.Remove(employeeClass);
            await _context.SaveChangesAsync();

            return Ok(employeeClass);
        }

        private bool EmployeeClassExists(int id)
        {
            return _context.EmployeeClass.Any(e => e.StudentID == id);
        }
    }
}