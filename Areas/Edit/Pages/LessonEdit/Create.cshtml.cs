using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.LessonEdit
{
    public class CreateModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public CreateModel(DiplomaWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClassroomID"] = new SelectList(_context.Classrooms, "ID", "ID");
        ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID");
        ViewData["SubjectID"] = new SelectList(_context.Subjects, "ID", "ID");
        ViewData["TeacherID"] = new SelectList(_context.Teachers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Lesson Lesson { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Lessons == null || Lesson == null)
            {
                return Page();
            }

            _context.Lessons.Add(Lesson);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
