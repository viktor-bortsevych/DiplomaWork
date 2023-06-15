using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.LessonEdit
{
    public class DeleteModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public DeleteModel(DiplomaWork.Data.ApplicationDbContext context)
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

            var lesson = await _context.Lessons.FirstOrDefaultAsync(m => m.ID == id);

            if (lesson == null)
            {
                return NotFound();
            }
            else 
            {
                Lesson = lesson;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Lessons == null)
            {
                return NotFound();
            }
            var lesson = await _context.Lessons.FindAsync(id);

            if (lesson != null)
            {
                Lesson = lesson;
                _context.Lessons.Remove(Lesson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
