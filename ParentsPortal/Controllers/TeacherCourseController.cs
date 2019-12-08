using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParentsPortal.Models;

namespace ParentsPortal.Controllers
{
    public class TeacherCourseController : Controller
    {
        private readonly ParentsDbContext _context;

        public TeacherCourseController(ParentsDbContext context)
        {
            _context = context;
        }

        // GET: TeacherCourse
        public async Task<IActionResult> Index()
        {
            var parentsDbContext = _context.TeacherCourse.Include(t => t.Course).Include(t => t.Teacher);
            return View(await parentsDbContext.ToListAsync());
        }

        // GET: TeacherCourse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourse
                .Include(t => t.Course)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherCourseId == id);
            if (teacherCourse == null)
            {
                return NotFound();
            }

            return View(teacherCourse);
        }

        // GET: TeacherCourse/Create
        public IActionResult Create()
        {
            ViewData["CrsId"] = new SelectList(_context.Course, "CrsId", "CourseId");
            ViewData["TcrId"] = new SelectList(_context.Teacher, "TcrId", "TeacherId");
            return View();
        }

        // POST: TeacherCourse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherCourseId,TcrId,CrsId")] TeacherCourse teacherCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CrsId"] = new SelectList(_context.Course, "CrsId", "CourseId", teacherCourse.CrsId);
            ViewData["TcrId"] = new SelectList(_context.Teacher, "TcrId", "TeacherId", teacherCourse.TcrId);
            return View(teacherCourse);
        }

        // GET: TeacherCourse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourse.FindAsync(id);
            if (teacherCourse == null)
            {
                return NotFound();
            }
            ViewData["CrsId"] = new SelectList(_context.Course, "CrsId", "CourseId", teacherCourse.CrsId);
            ViewData["TcrId"] = new SelectList(_context.Teacher, "TcrId", "TeacherId", teacherCourse.TcrId);
            return View(teacherCourse);
        }

        // POST: TeacherCourse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherCourseId,TcrId,CrsId")] TeacherCourse teacherCourse)
        {
            if (id != teacherCourse.TeacherCourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherCourseExists(teacherCourse.TeacherCourseId))
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
            ViewData["CrsId"] = new SelectList(_context.Course, "CrsId", "CourseId", teacherCourse.CrsId);
            ViewData["TcrId"] = new SelectList(_context.Teacher, "TcrId", "TeacherId", teacherCourse.TcrId);
            return View(teacherCourse);
        }

        // GET: TeacherCourse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourse
                .Include(t => t.Course)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherCourseId == id);
            if (teacherCourse == null)
            {
                return NotFound();
            }

            return View(teacherCourse);
        }

        // POST: TeacherCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherCourse = await _context.TeacherCourse.FindAsync(id);
            _context.TeacherCourse.Remove(teacherCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherCourseExists(int id)
        {
            return _context.TeacherCourse.Any(e => e.TeacherCourseId == id);
        }
    }
}
