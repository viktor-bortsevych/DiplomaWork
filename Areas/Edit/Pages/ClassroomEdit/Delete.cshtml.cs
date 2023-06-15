using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DiplomaWork.Data;
using DiplomaWork.Data.Models;

namespace DiplomaWork.Areas.Edit.Pages.ClassroomEdit
{
    public class DeleteModel : PageModel
    {
        private readonly DiplomaWork.Data.ApplicationDbContext _context;

        public DeleteModel(DiplomaWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Classroom Classroom { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Classrooms == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms.FirstOrDefaultAsync(m => m.ID == id);

            if (classroom == null)
            {
                return NotFound();
            }
            else 
            {
                Classroom = classroom;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Classrooms == null)
            {
                return NotFound();
            }
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom != null)
            {
                Classroom = classroom;
                _context.Classrooms.Remove(Classroom);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
