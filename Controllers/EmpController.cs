using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpApi.Models;

namespace EmpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly EmpContext _context;

        public EmpController(EmpContext context)
        {
            _context = context;

            if (_context.EmpCollection.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.EmpCollection.Add(new Employee { FirstName = "John", LastName = "Doe", DateOfJoining = System.DateTime.Now, Manager = "Tom", IsActive = true });
                _context.SaveChanges();
            }
        }

        // GET: api/Emp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.EmpCollection.ToListAsync();
        }

        // GET: api/Emp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            var emp = await _context.EmpCollection.FindAsync(id);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }

        // POST: api/emp
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmp(Employee emp)
        {
            emp.DateOfJoining = DateTime.Now;
            emp.IsActive = true;
            _context.EmpCollection.Add(emp);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = emp.Id }, emp);
        }

        // PUT: api/emp/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmp(long id, Employee emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
            }

            _context.Entry(emp).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/emp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmp(long id)
        {
            var emp = await _context.EmpCollection.FindAsync(id);

            if (emp == null)
            {
                return NotFound();
            }

            _context.EmpCollection.Remove(emp);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}