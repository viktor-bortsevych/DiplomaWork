using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.LessonEdit
{
    public class EditModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public EditModel(DiplomaWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lesson Lesson { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Lessons == null)
            {
                return NotFound();
            }

            var lesson =  await _context.Lessons.FirstOrDefaultAsync(m => m.ID == id);
            if (lesson == null)
            {
                return NotFound();
            }
            Lesson = lesson;
           ViewData["ClassroomID"] = new SelectList(_context.Classrooms, "ID", "ID");
           ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID");
           ViewData["SubjectID"] = new SelectList(_context.Subjects, "ID", "ID");
           ViewData["TeacherID"] = new SelectList(_context.Teachers, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Lesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(Lesson.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LessonExists(string id)
        {
          return (_context.Lessons?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
