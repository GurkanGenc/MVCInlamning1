using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Entities;

namespace SchoolApp.Controllers
{
    public class SchoolClassesStudentsController : Controller
    {
        private readonly SchoolAppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public SchoolClassesStudentsController(SchoolAppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: SchoolClassesStudents
        public async Task<IActionResult> Index()
        {
            var schoolAppDbContext = _context.SchoolClassesStudents.Include(s => s.SchoolClass);
            return View(await schoolAppDbContext.ToListAsync());
        }

        // GET: SchoolClassesStudents/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClassesStudent = await _context.SchoolClassesStudents
                .Include(s => s.SchoolClass)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (schoolClassesStudent == null)
            {
                return NotFound();
            }

            return View(schoolClassesStudent);
        }

        // GET: SchoolClassesStudents/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Students = await _userManager.GetUsersInRoleAsync("Student");

            ViewData["SchoolClassId"] = new SelectList(_context.SchoolClasses, "Id", "ClassName");
            return View();
        }

        // POST: SchoolClassesStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,SchoolClassId")] SchoolClassesStudent schoolClassesStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolClassesStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SchoolClassId"] = new SelectList(_context.SchoolClasses, "Id", "ClassName", schoolClassesStudent.SchoolClassId);
            return View(schoolClassesStudent);
        }

        // GET: SchoolClassesStudents/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClassesStudent = await _context.SchoolClassesStudents.FindAsync(id);
            if (schoolClassesStudent == null)
            {
                return NotFound();
            }
            ViewData["SchoolClassId"] = new SelectList(_context.SchoolClasses, "Id", "ClassName", schoolClassesStudent.SchoolClassId);
            return View(schoolClassesStudent);
        }

        // POST: SchoolClassesStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentId,SchoolClassId")] SchoolClassesStudent schoolClassesStudent)
        {
            if (id != schoolClassesStudent.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolClassesStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolClassesStudentExists(schoolClassesStudent.StudentId))
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
            ViewData["SchoolClassId"] = new SelectList(_context.SchoolClasses, "Id", "ClassName", schoolClassesStudent.SchoolClassId);
            return View(schoolClassesStudent);
        }

        // GET: SchoolClassesStudents/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClassesStudent = await _context.SchoolClassesStudents
                .Include(s => s.SchoolClass)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (schoolClassesStudent == null)
            {
                return NotFound();
            }

            return View(schoolClassesStudent);
        }

        // POST: SchoolClassesStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var schoolClassesStudent = await _context.SchoolClassesStudents.FindAsync(id);
            _context.SchoolClassesStudents.Remove(schoolClassesStudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolClassesStudentExists(string id)
        {
            return _context.SchoolClassesStudents.Any(e => e.StudentId == id);
        }
    }
}
