using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.TeacherEdit
{
    public class DeleteModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public DeleteModel(DiplomaWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Teacher Teacher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }
            else 
            {
                Teacher = teacher;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher != null)
            {
                Teacher = teacher;
                _context.Teachers.Remove(Teacher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
